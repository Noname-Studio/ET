using ET;

namespace Client.Event
{
    public struct GuildMessageChanged : IEventHandle
    {
        public CS2C_GuildMessageChanged Message { get; }

        public GuildMessageChanged(CS2C_GuildMessageChanged message)
        {
            Message = message;
        }
    }
}