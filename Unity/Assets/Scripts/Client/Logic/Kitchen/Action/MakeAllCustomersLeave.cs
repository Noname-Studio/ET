namespace Kitchen.Action
{
    public struct MakeAllCustomersLeave : IGameAction
    {
        public void Execute()
        {
            //令所有顾客离场
            foreach (var node in KitchenRoot.Inst.Units.GetCustomers())
            {
                if (node is NormalCustomer customer)
                {
                    if (customer.PatienceCom != null)
                    {
                        customer.PatienceCom.Value = 0;
                    }
                    else
                    {
                        customer.OnExit();
                    }
                }
            }
        }

        public bool Update()
        {
            return true;
        }
    }
}