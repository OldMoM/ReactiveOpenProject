using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IngameDebugConsole;

namespace Peixi
{
    public class DebugCommands : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DebugLogConsole.AddCommand<string,int>("player.additem", "", (string item,int amount) =>
            {
                InterfaceManager.manager.InventorySystem.AddItem(item, amount);
            });

            DebugLogConsole.AddCommand<string, int>("player.removeitem", "", (string item, int amount) =>
            {
                InterfaceManager.manager.InventorySystem.RemoveItem(item, amount);
            });
        }
    }
}
