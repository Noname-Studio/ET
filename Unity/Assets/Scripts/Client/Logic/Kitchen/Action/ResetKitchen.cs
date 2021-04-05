namespace Kitchen.Action
{
    /// <summary>
    /// 重置后厨的所有状态.
    /// 清空特效
    /// 清空所有已经完成的内容
    /// </summary>
    public struct ResetKitchen : IGameAction
    {
        public void Execute()
        {
            //令所有已完成要素归零
            KitchenRoot.Inst.Record.Reset();
            //清除场景内容
            KitchenRoot.Inst.Reset();
        }

        public bool Update()
        {
            return true;
        }
    }
}