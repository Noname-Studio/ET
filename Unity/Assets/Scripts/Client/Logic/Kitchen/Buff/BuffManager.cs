/*
namespace Kitchen
{
    /// <summary>
    /// 使用这个类给单位增加Buff
    /// </summary>
    public class BuffManager
    {
        private static BuffManager mInst;
        public static BuffManager Inst
        {
            get
            {
                if(mInst == null)
                    mInst = new BuffManager();
                return mInst;
            }
        }
        
        public void Apply(IUnit unit,IBuff buff)
        {
            if (!CheckConditionVaild(unit, buff)) return;
            unit.Buff.Add(buff);
        }
        
        public void Remove(IUnit unit, IBuff buff)
        {
            if (!CheckConditionVaild(unit, buff)) return;
            unit.Buff.Remove(buff);
        }
        
        public void Remove(IUnit unit, IBuff buff, int stack)
        {
            
        }
        
        private static bool CheckConditionVaild(IUnit unit, IBuff buff)
        {
            if (unit.Buff == null)
            {
                Logger.LogError("该单位不支持添加Debuff");
                return false;
            }

            if (buff == null)
            {
                Logger.LogError("Buff不能为Null");
                return false;
            }

            return true;
        }
    }
}
*/

