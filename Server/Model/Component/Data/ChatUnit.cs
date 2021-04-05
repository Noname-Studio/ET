namespace ET
{
    public class ChatUnitAwakeSystem : AwakeSystem<ChatUnit>
    {
        public override void Awake(ChatUnit self)
        {
            self.Awake();
        }
    }

    public sealed class ChatUnit: Entity
    {
        public long GateSessionId { get; set; }
        public Scene Scene { get; set; }
        public string Head { get; set; }
        public string Name { get; set; }
        public long GuildId { get; set; }
        public long PlayerId { get; set; }
        public void Awake()
        {
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();
        }
    }
}