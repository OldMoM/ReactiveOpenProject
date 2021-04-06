using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Peixi;
using UniRx;

namespace Tests
{
    public class InventoryCorePresenterTest
    {
        // A Test behaves as an ordinary method

        InventoryCorePresenter CreateInventoryCorePresenter()
        {
            var core = new InventoryCorePresenter();
            core.Init();
            return core;
        }

        [Test]
        public void AddTwoItem_fiberAndfiber()
        {
            //Arrange
            var core = CreateInventoryCorePresenter();

            core.AddNewItem("fiber", 3);
            core.AddNewItem("fiber", 2);

            Assert.AreEqual("fiber", core.items[0].Name);
            Assert.AreEqual(3, core.items[0].Amount);
            Assert.AreEqual(false, core.items[0].IsEmpty);

            Assert.AreEqual("fiber", core.items[1].Name);
        }
        [Test]
        public void RemoveItem_0()
        {
            var core = CreateInventoryCorePresenter();

            core.AddNewItem("fiber", 2);
            core.AddNewItem("fiber", 3);

            core.RemoveItem("fiber");

            Assert.AreEqual(0, core.items[0].Amount);
            Assert.AreEqual(0, core.items[1].Amount);
        }
        [Test]
        public void ModifyItem_changeValueEqualsRemainValue_clearGrid()
        {
            var core = CreateInventoryCorePresenter();

            core.AddNewItem("fiber", 2);
            core.ModifiyItem("fiber", -2);

            Assert.IsTrue(core.items[0].IsEmpty);
        }
        [Test]
        public void OnItemAdded_fiber()
        {
            var core = CreateInventoryCorePresenter();

            core.OnInventoryModified
                .Subscribe(x =>
                {
                    Debug.Log("on item added");
                    Assert.AreEqual("fiber", x.NewValue.Name);
                });

            core.AddNewItem("fiber");

            
        }
        [Test]
        public void GetAmount_NoItem_0()
        {
            var core = CreateInventoryCorePresenter();

            var fiberAmount = core.GetAmount("fiber");

            Assert.AreEqual(0, fiberAmount);
            
        }
        [Test]
        public void GetAmount_FindFiber_4()
        {
            var core = CreateInventoryCorePresenter();

            core.AddNewItem("fiber", 2);
            core.ModifiyItem("fiber", 2);
            Assert.AreEqual(4, core.GetAmount("fiber"));
        }

       [Test]
       public void AddTwoItem_icon_2()
        {
            //Arrange
            var core = new InventoryCorePresenter();
            core.Init();
            //Assert
            core.OnInventoryModified.Subscribe(x =>
            {
                Debug.Log("Get " + x.NewValue.Name + " at amount of " + x.NewValue.Amount);

                Assert.AreEqual("iron", x.NewValue.Name);
                Assert.AreEqual(2, x.NewValue.Amount);
            });
            //Act
            core.AddNewItem("iron", 2);
        }
    }
}
