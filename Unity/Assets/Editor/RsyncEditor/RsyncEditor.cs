using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public class RsyncEditor: EditorWindow
    {
        private const string ConfigFile = @"..\Tools\cwRsync\Config\rsyncConfig.txt";
        private RsyncConfig rsyncConfig;
        private bool isFold = true;

        [MenuItem("Tools/Rsync同步")]
        private static void ShowWindow()
        {
            GetWindow(typeof (RsyncEditor));
        }

        private void OnEnable()
        {
            if (!File.Exists(ConfigFile))
            {
                rsyncConfig = new RsyncConfig();
                return;
            }

            string s = File.ReadAllText(ConfigFile);
            rsyncConfig = MongoHelper.FromJson<RsyncConfig>(s);
        }

        private void OnGUI()
        {
            rsyncConfig.Host = EditorGUILayout.TextField("服务器地址", rsyncConfig.Host);
            rsyncConfig.Account = EditorGUILayout.TextField("账号（必须是Linux已有的账号）", rsyncConfig.Account);
            rsyncConfig.Password = EditorGUILayout.TextField("密码", rsyncConfig.Password);
            rsyncConfig.RelativePath = EditorGUILayout.TextField("相对路径", rsyncConfig.RelativePath);

            isFold = EditorGUILayout.Foldout(isFold, $"排除列表:");

            if (!isFold)
            {
                for (int i = 0; i < rsyncConfig.Exclude.Count; ++i)
                {
                    GUILayout.BeginHorizontal();
                    rsyncConfig.Exclude[i] = EditorGUILayout.TextField(rsyncConfig.Exclude[i]);
                    if (GUILayout.Button("删除"))
                    {
                        rsyncConfig.Exclude.RemoveAt(i);
                        break;
                    }

                    GUILayout.EndHorizontal();
                }
            }

            if (GUILayout.Button("添加排除项目"))
            {
                rsyncConfig.Exclude.Add("");
            }

            if (GUILayout.Button("保存"))
            {
                File.WriteAllText(ConfigFile, MongoHelper.ToJson(rsyncConfig));
                using (StreamWriter sw = new StreamWriter(new FileStream(@"..\Tools\cwRsync\Config\exclude.txt", FileMode.Create)))
                {
                    foreach (string s in rsyncConfig.Exclude)
                    {
                        sw.Write(s + "\n");
                    }
                }

                File.WriteAllText($@"..\Tools\cwRsync\Config\rsync.secrets", rsyncConfig.Password);
                File.WriteAllText($@"..\Tools\cwRsync\Config\rsyncd.secrets", $"{rsyncConfig.Account}:{rsyncConfig.Password}");

                string rsyncdConf = "uid = 0\n" + "gid = 0\n" + "use chroot = no\n" + "max connections = 100\n" + "read only = no\n" +
                        "write only = no\n" +
                        "log file =/var/log/rsyncd.log\n" + "fake super = yes\n" + "[Upload]\n" + $"path = /home/{rsyncConfig.Account}/\n" +
                        $"auth users = {rsyncConfig.Account}\n" + "secrets file = /etc/rsyncd.secrets\n" + "list = yes";
                File.WriteAllText($@"..\Tools\cwRsync\Config\rsyncd.conf", rsyncdConf);
            }

            if (GUILayout.Button("同步"))
            {
                string arguments =
                        $"-vzrtopg --password-file=./Tools/cwRsync/Config/rsync.secrets --exclude-from=./Tools/cwRsync/Config/exclude.txt --delete ./ {rsyncConfig.Account}@{rsyncConfig.Host}::Upload/{rsyncConfig.RelativePath} --chmod=ugo=rwX";
                ProcessHelper.Run(@"./Tools/cwRsync/rsync.exe", arguments, @"..\", true);
                Log.Info("同步完成!");
            }
        }
    }
}