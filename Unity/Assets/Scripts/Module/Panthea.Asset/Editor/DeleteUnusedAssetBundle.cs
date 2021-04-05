using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEditor.Build.Pipeline;
using UnityEditor.Build.Pipeline.Injector;
using UnityEditor.Build.Pipeline.Interfaces;
using UnityEditor.Graphs;

namespace Panthea.Editor.Asset
{
    public class DeleteUnusedAssetBundle: IBuildTask
    {
#pragma warning disable 649
        [InjectContext(ContextUsage.In)]
        private IBuildParameters m_Parameters;

        [InjectContext(ContextUsage.In)]
        private IBundleBuildContent m_Content;

#pragma warning restore 649

        public ReturnCode Run()
        {
            var outputFolder = ((AddressableAssetsBundleBuildParameters) m_Parameters).OutputFolder;
            var allAssetbundle = Directory.GetFiles(outputFolder + "/", "*.bundle", SearchOption.AllDirectories);
            foreach (var node in allAssetbundle)
            {
                string path = PathUtils.FormatFilePath(node.Replace(outputFolder + "/", ""));
                if (!m_Content.BundleLayout.ContainsKey(path))
                {
                    File.Delete(node);
                }
            }

            RemoveEmptyDir(outputFolder + "/");
            return ReturnCode.Success;
        }

        private void RemoveEmptyDir(string path)
        {
            var dir = new DirectoryInfo(path);
            var allDir = dir.GetDirectories();
            var allFile = dir.GetFiles();
            if (allDir.Length != 0)
            {
                foreach (var node in allDir)
                {
                    RemoveEmptyDir(node.FullName);
                }
            }

            if ((allFile.Length == 0 || allFile.All(t1 => t1.Extension == ".meta")) && dir.GetDirectories().Length == 0)
            {
                FileUtil.DeleteFileOrDirectory(PathUtils.FullPathToUnityPath(dir.FullName));
                var metaPath = dir.FullName + ".meta";
                if (File.Exists(metaPath))
                {
                    FileUtil.DeleteFileOrDirectory(PathUtils.FullPathToUnityPath(metaPath));
                }

                return;
            }
        }

        public int Version => 1;
    }
}