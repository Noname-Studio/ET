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
		public static async ETTask StartNet()
		{
			try
			{
				//SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
				
				string[] assemblyNames = { "Unity.Model.dll", "Unity.Hotfix.dll", "Unity.ModelView.dll", "Unity.HotfixView.dll" };
				
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
			}
			catch (Exception e)
			{
				Log.Error(e);
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