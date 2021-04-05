using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public class AssetsBundleLoaderAsyncSystem: UpdateSystem<AssetsBundleLoaderAsync>
    {
        public override void Update(AssetsBundleLoaderAsync self)
        {
            self.Update();
        }
    }

    public class AssetsBundleLoaderAsync: Entity
    {
        private AssetBundleCreateRequest request;

        private ETTaskCompletionSource<AssetBundle> tcs;

        public void Update()
        {
            if (!request.isDone)
            {
                return;
            }

            ETTaskCompletionSource<AssetBundle> t = tcs;
            t.SetResult(request.assetBundle);
        }

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            base.Dispose();
        }

        public ETTask<AssetBundle> LoadAsync(string path)
        {
            tcs = new ETTaskCompletionSource<AssetBundle>();
            request = AssetBundle.LoadFromFileAsync(path);
            return tcs.Task;
        }
    }
}