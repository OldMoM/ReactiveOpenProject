using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System;
using UnityEngine.Assertions;

namespace Peixi
{
    /// <summary>
    ///   <para>基础设施层：只提供查询，写入和读取操作</para>
    ///   <para>
    ///     <br />
    ///   </para>
    /// </summary>
    /// <remarks>构造函数启动改为：提供Init方法，手段启动，增加其可测试性@wip</remarks>
    public class InventoryCorePresenter 
    {
        private InventoryModel<InventoryGridData> model = new InventoryModel<InventoryGridData>();

        public int gridCapacity = 9;
        public IObservable<CollectionReplaceEvent<InventoryGridData>> OnInventoryModified => model.set.ObserveReplace();
        public List<InventoryGridData> items => model.set.ToList();
        public InventoryCorePresenter() { }

        public void Init()
        {
            //创建核心数据

            //断言


            //初始创建9个数据格
            for (int i = 0; i < gridCapacity; i++)
            {
                var _gridData = new InventoryGridData(i, "", 0, true);
                model.set.Add(_gridData);
            }
        }
        /// <summary>在空背包格中添加物品</summary>
        /// <param name="name">The name.</param>
        /// <param name="amount">The amount.</param>
        public void AddNewItem(string name,int amount=1)
        {
            var searchGrid = model.set
                 .ToObservable();

            searchGrid
                .Where(x => x.IsEmpty)
                .Take(1)
                .Subscribe(y =>
                {
                    var data_temp = y;
                    data_temp.Amount += amount;
                    data_temp.Name = name;
                    data_temp.IsEmpty = false;
                    model.set[data_temp.Position] = data_temp;
                }); 
        }
        /// <summary>Removes the item.</summary>
        /// <param name="name">The name.</param>
        public void RemoveItem(string name)
        {
            items.ToObservable()
                .Where(x => x.Name == name)
                .Subscribe(x =>
                {
                    var posInInventoryGrid = x.Position;
                    var emptyGrid = new InventoryGridData(posInInventoryGrid, "", 0, true);
                    model.set[posInInventoryGrid] = emptyGrid;
                });
        }
        /// <summary>
        ///   <para>Modifiys the item.</para>
        ///   <para>当移除量&gt;剩余量时则无法进行操作，并抛出异常</para>
        ///   <para>当移除量=剩余量时则自动清空背包格</para>
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="change">The change value.</param>
        public void ModifiyItem(string name,int change)
        {
            items.ToObservable()
                .Where(x => x.Name == name)
                .Subscribe(x =>
                {
                    if (x.Amount+change < 0)
                    {
                        throw new Exception("当移除量<剩余量时则无法进行操作");
                    }
                    else if (x.Amount + change == 0)
                    {
                        RemoveItem(x.Name);
                    }
                    else
                    {
                        x.Amount += change;
                        var posInInventoryGrid = x.Position;
                        model.set[posInInventoryGrid] = x;
                    }
                });
        }
        /// <summary>
        ///   <para>
        /// Gets the amount.
        /// </para>
        ///   <para>如果没有item则返回0</para>
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public int GetAmount(string name)
        {
            var thePointedItem = items.Find(x => x.Name == name);
            return thePointedItem.Amount;       
        }
    }
}

