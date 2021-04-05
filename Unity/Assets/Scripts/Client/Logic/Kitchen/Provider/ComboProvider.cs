using Client.Event;

namespace Kitchen.Provider
{
    public class ComboProvider
    {
        public int ComboLevel { get; private set; } = 0;
        public const int MaxCombo = 5;

        public void LevelUp()
        {
            ComboLevel++;
            if (ComboLevel == MaxCombo)
            {
                MessageKit.Inst.Send(new MaxCombo(ComboLevel));
                Clear();
                return;
            }
            MessageKit.Inst.Send(new ComboLevelUp(ComboLevel));
        }

        public void Clear()
        {
            ComboLevel = 0;
        }
    }
}