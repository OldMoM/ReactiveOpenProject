using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Peixi
{
    public interface IInterfaceManager 
    {
        IObservable<IInventorySystem> OnInventorySystemActived { get; }
        IInventorySystem InventorySystem { get; }
    }
}
