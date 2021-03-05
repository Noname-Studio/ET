using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Kitchen
{
    /// <summary>
    /// 厨具上放置的食材信息类
    /// 一些厨具上需要放置多个食材才能进行任务.
    /// </summary>
    public class PlacedIngredients 
    {
        private List<string> mList = new List<string>();
        /// <summary>
        /// 放置在厨具上的食材列表,修改内容请使用Add或者Remove和Get
        /// </summary>
        public ReadOnlyCollection<string> List => mList.AsReadOnly();
        public event Action<string> OnAdded;
        public event Action<string> OnRemoved;
        public event Action OnChanged;

        public void Add(string ingredient)
        {
            mList.Add(ingredient);
            if (OnAdded != null) OnAdded(ingredient);
            if (OnChanged != null) OnChanged();
        }

        public void Remove(string ingredient)
        {
            mList.Remove(ingredient);
            if (OnRemoved != null) OnRemoved(ingredient);
            if (OnChanged != null) OnChanged();
        }
        
        public bool Get(string ingredient)
        {
            for (var index = 0; index < mList.Count; index++)
            {
                var node = mList[index];
                if (node == ingredient)
                {
                    Remove(ingredient);
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            mList.Clear();
            if (OnChanged != null) OnChanged();
        }
    }
}
