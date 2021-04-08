using System;
using System.Threading;
using CommandLine;
using ET;
using NLog;

namespace ETManagerConsole
{
    class Program
    {
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
                Options options = null;
                Parser.Default.ParseArguments<Options>(args)
                        .WithNotParsed(error => throw new Exception($"命令行格式错误!"))
                        .WithParsed(o => { options = o; });

                Game.Options = options;
				
                LogManager.Configuration.Variables["appIdFormat"] = $"{Game.Scene.Id:0000}";
                Log.Info($"server start........................ {Game.Scene.Id}");
                var kcpComponent = Game.Scene.AddComponent<NetKcpComponent>();
                while (true)
                {
                    if (Console.ReadLine() == "Update")
                    {
                        using (Session session = kcpComponent.Create(NetworkHelper.ToIPEndPoint("192.168.3.29:50002")))
                        {
                            session.Send(new C2G_Reload());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}