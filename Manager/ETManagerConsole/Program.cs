using System;
using System.Threading;
using System.Threading.Tasks;
using ET;
using ETManagerConsole.Component;
using NLog;

namespace ETManagerConsole
{
    class Program
    {
        private static string GateIP
        {
            get
            {
                return "192.168.3.29:50003";
            }
        }
        private static void Main(string[] args)
        {
            // 异步方法全部会回掉到主线程
            SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
            try
            {		
                Game.EventSystem.Add(typeof(Game).Assembly);
                Game.EventSystem.Add(DllHelper.GetHotfixAssembly());

                ProtobufHelper.Init();
                MongoHelper.Init();
				
                // 命令行参数

                Game.Options = new Options();
                LogManager.Configuration.Variables["appIdFormat"] = $"{Game.Scene.Id:0000}";
                Log.Info($"server start........................ {Game.Scene.Id}");
                Game.Scene.AddComponent<TimerComponent>();
                Game.Scene.AddComponent<CoroutineLockComponent>();
                Game.Scene.AddComponent<OpcodeTypeComponent>();
                Game.Scene.AddComponent<MessageDispatcherComponent>();
                //Game.Scene.AddComponent<UIEventComponent>();
                Game.Scene.AddComponent<NetThreadComponent>();
                var kcpComponent = Game.Scene.AddComponent<NetKcpComponent>();

                Task.Run(DoJob);
                while (true)
                {
                    try
                    {
                        Thread.Sleep(1);
                        Game.Update();
                        Game.LateUpdate();
                        Game.FrameFinish();
                    }
                    catch (Exception e)
                    {
                        Log.Error(e);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static async ETTask DoJob()
        {
            try
            {
                var kcpComponent = Game.Scene.GetComponent<NetKcpComponent>();
                await Task.Run(async () =>
                {
                    while (true)
                    {
                        try
                        {
                            var command = Console.ReadLine();
                            if (command == "Update")
                            {
                                using (Session gateSession = kcpComponent.Create(NetworkHelper.ToIPEndPoint(GateIP)))
                                {
                                    await gateSession.Call(new C2G_Reload());
                                }
                            }

                            if (command == "SafeClose")
                            {
                                using (Session gateSession = kcpComponent.Create(NetworkHelper.ToIPEndPoint(GateIP)))
                                {
                                    await gateSession.Call(new C2G_SafeShutdown());
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Log.Error(e);
                        }
                    }
                });
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}