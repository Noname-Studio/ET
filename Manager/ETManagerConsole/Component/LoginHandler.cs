using ET;

namespace ETManagerConsole.Component
{
    public class LoginHandler : AMHandler<R2C_Login>
    {
        protected override async ETVoid Run(Session session, R2C_Login message)
        {
            Log.Error("!!!!");
            await ETTask.CompletedTask;
        }
    }
}