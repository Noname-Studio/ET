using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
    public class UnitManager
    {
        private HashSet<IUnit> List { get; } = new HashSet<IUnit>();
        private List<ACustomer> Customers { get; } = new List<ACustomer>();

        private PlayerController Player { get; set; }

        public PlayerController GetPlayer()
        {
            if (Player != null)
            {
                return Player;
            }

            foreach (var node in List)
            {
                if (node is PlayerController result)
                {
                    Player = result;
                }
            }

            return Player;
        }

        public List<ACustomer> GetCustomers()
        {
            return Customers;
        }

        public void Register(IUnit unit)
        {
            if (!List.Add(unit))
            {
                Log.Warning("重复添加单位");
            }
            else
            {
                if (unit is PlayerController controller)
                    Player = controller;
                else if (unit is ACustomer customer)
                    Customers.Add(customer);
            }
        }

        public void Update()
        {
            foreach (var node in List)
            {
                node.Update();
            }
        }

        public void Dispose()
        {
            foreach (var node in List)
            {
                node.Dispose();
            }
        }
    }
}