using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
    public class UnitManager
    {
        private static UnitManager mInst;
        public static UnitManager Inst => mInst ?? (mInst = new UnitManager());
        
        private HashSet<IUnit> List { get; } = new HashSet<IUnit>();
        private PlayerController Player { get; set; }
        public PlayerController GetPlayer()
        {
            if (Player != null)
                return Player;
            foreach (var node in List)
            {
                if (node is PlayerController result)
                {
                    Player = result;
                }
            }
            return Player;
        }

        public void Register(IUnit unit)
        {
            if (!List.Add(unit))
                Log.Warning("重复添加单位");
        }
    }
}