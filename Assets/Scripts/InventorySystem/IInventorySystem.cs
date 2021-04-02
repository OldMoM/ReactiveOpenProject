using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

namespace Peixi
{
    public interface IInventorySystem
    {
        /// <summary>
        /// 查询背包中Item的数量
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetItemAmount(string name);
        /// <summary>
        /// 移除背包中的Item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        void RemoveItem(string name, int amount = 1);
        /// <summary>
        /// 向背包中添加Item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        void AddItem(string name, int amount = 1);
        /// <summary>
        /// 当修改背包中Item数据被修改时触发此事件
        /// </summary>
        IObservable<CollectionReplaceEvent<InventoryGridData>> OnInventoryChanged { get; }
    }
}
