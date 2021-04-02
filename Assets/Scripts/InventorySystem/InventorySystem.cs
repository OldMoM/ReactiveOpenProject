using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace Peixi
{
    /// <summary>
    ///   <para>设计思路：背包的本质就是Crud操作</para>
    ///   <para>功能需求：使用Excel管理物品信息----MVP架构</para>
    ///   <para>                   背包数据要便于保存成json文件-----业务和数据分析</para>
    ///   <para>                   背包中有3个栏位容纳：材料，消耗品，重要物品</para>
    ///   <para>                   *背包有重量上线</para>
    ///   <para>构成模块：<br /></para>
    /// </summary>
    /// <seealso cref="InventoryGui" />
    public class InventorySystem : MonoBehaviour, IInventorySystem
    {
        private InventoryCorePresenter presenter;
        private AddItemAgent addItemAgent;
        //InventoryGui gui;

        public InventorySetting setting;

        #region//implement interface
        public IObservable<CollectionReplaceEvent<InventoryGridData>> OnInventoryChanged => presenter.OnInventoryModified;
        public void AddItem(string name, int amount = 1)
        {
            addItemAgent.AddItem(name, amount);
        }
        public int GetItemAmount(string itemName)
        {
            return presenter.GetAmount(itemName);
        }
        public void RemoveItem(string name, int amount = 1)
        {
            presenter.ModifiyItem(name, -amount);
        }
        #endregion
        private void OnEnable()
        {
            presenter = new InventoryCorePresenter();
            presenter.Init();
            addItemAgent = new AddItemAgent(presenter);
        }
    }
}
