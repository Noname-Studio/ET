using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public class Init
    {
        private enum ETState
        {
            NotInit,Running,Complete
        }

        private static ETState Initialize { get; set; } = ETState.NotInit;
        private static TaskCompletionSource<bool> RunningTask = new TaskCompletionSource<bool>();
        public static async ETTask<bool> StartNet()
        {
            if (Initialize == ETState.Running)
            {
                return await RunningTask.Task;
            }
            else if (Initialize == ETState.Complete)
                return true;
            try
            {
                //SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
                Initialize = ETState.Running;
                RunningTask = new TaskCompletionSource<bool>();
                string[] assemblyNames =
                {
                    "Unity.Model.dll", "Unity.Hotfix.dll", "Unity.ModelView.dll", "Unity.HotfixView.dll", "PantheaFW.Core.dll"
                };

                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    string assemblyName = assembly.ManifestModule.Name;
                    if (!assemblyNames.Contains(assemblyName))
                    {
                        continue;
                    }

                    Game.EventSystem.Add(assembly);
                }

                ProtobufHelper.Init();

                Game.Options = new Options();

                await Game.EventSystem.Publish(new EventType.AppStart());

                UnityLifeCycleKit.Inst.AddUpdate(Update);
                UnityLifeCycleKit.Inst.AddLateUpdate(LateUpdate);
                UnityLifeCycleKit.Inst.ApplicationQuitEvent += OnApplicationQuit;
                Initialize = ETState.Complete;
                RunningTask.SetResult(true);
                return true;
            }
            catch (Exception e)
            {
                Log.Error(e);
                Initialize = ETState.NotInit;
                RunningTask.SetResult(false);
                return false;
            }
        }

        private static float Update()
        {
            ThreadSynchronizationContext.Instance.Update();
            Game.EventSystem.Update();
            return 0;
        }

        private static float LateUpdate()
        {
            Game.EventSystem.LateUpdate();
            return 0;
        }

        private static void OnApplicationQuit()
        {
            Game.Close();
        }
    }
}