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