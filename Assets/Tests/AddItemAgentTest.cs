using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Peixi;

namespace Tests
{
    public class AddItemAgentTest
    {
        InventoryCorePresenter CreateInventoryCorePresenter()
        {
            var core = new InventoryCorePresenter();
            core.Init();
            return core;
        }
        // A Test behaves as an ordinary method
        [Test]
        public void AddItem_NotHasSameItem_1fiberAnd2plastic()
        {
            var core = CreateInventoryCorePresenter();
            var agent = new AddItemAgent(core);

            agent.AddItem("fiber", 1);
            agent.AddItem("plastic", 2);

            Assert.AreEqual(1, core.items[0].Amount);
            Assert.AreEqual("fiber", core.items[0].Name);

            Assert.AreEqual(2, core.items[1].Amount);
            Assert.AreEqual("plastic", core.items[1].Name);
        }
        [Test]
        public void AddItem_HasSameItem_3FiberAnd2Plastic()
        {
            var core = CreateInventoryCorePresenter();
            var agent = new AddItemAgent(core);

            agent.AddItem("fiber", 1);
            agent.AddItem("plastic", 2);
            agent.AddItem("fiber", 2);

            Assert.AreEqual(3, core.items[0].Amount);
            Assert.AreEqual("fiber", core.items[0].Name);

            Assert.AreEqual(2, core.items[1].Amount);
            Assert.AreEqual("plastic", core.items[1].Name);
        }
    }
}
