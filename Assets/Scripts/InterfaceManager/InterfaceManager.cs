using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;


namespace Peixi
{
    public class InterfaceManager : MonoBehaviour,IInterfaceManager
    {
        private IInventorySystem iInventorySystem;

        private ReplaySubject<IInventorySystem> onInventorySystemActived = new ReplaySubject<IInventorySystem>();

        public IObservable<IInventorySystem> OnInventorySystemActived => onInventorySystemActived;

        IInventorySystem IInterfaceManager.InventorySystem => iInventorySystem;


        /// <summary>这是个假单例</summary>
        public static IInterfaceManager manager;
        

        void Start()
        {
            manager = this;

            var childNode = new GameObject();
            childNode.transform.SetParent(transform);
            childNode.name = "InventorySystem";
            iInventorySystem = childNode.AddComponent<InventorySystem>();
            onInventorySystemActived.OnNext(iInventorySystem);
        }
    }
}
