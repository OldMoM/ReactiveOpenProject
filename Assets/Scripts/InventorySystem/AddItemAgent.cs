using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Peixi
{
    /// <summary>
    ///   <para>功能：</para>
    ///   <para>1.在装入Item时，如果背包容量不够，不能装入，返回false回调</para>
    ///   <para>2.在装入Item时，如果背包超重，不能装入，返回false回调</para>
    ///   <para>3.按照Item种类装入不同背包</para>
    ///   <para>4.如果背包已有Item，数量+1</para>
    ///   <para>5.如果背包中没有Item，新建</para>
    /// </summary>
    public class AddItemAgent 
    {
        private InventoryCorePresenter core;
  
        public AddItemAgent(InventoryCorePresenter inventoryCorePresenter)
        {
            core = inventoryCorePresenter;
        }
        public void AddItem(string itemName,int amount = 1)
        {
            bool hasItem = false;

            var itemData = core.items.Find(x => x.Name == itemName);
            //core.items
            //    .ForEach(x =>
            //    {
            //        if (x.Name == itemName)
            //        {
            //            hasItem = true;
            //            return;
            //        }
            //    });

            if (itemData.Amount > 0)
            {
                core.ModifiyItem(itemName, amount);
            }
            else
            {
                core.AddNewItem(itemName, amount);
            }
        }
    }
}
