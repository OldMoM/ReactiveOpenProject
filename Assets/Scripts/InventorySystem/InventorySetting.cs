using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Peixi
{
    [Serializable]
    public struct InventorySetting
    {
        public int capacity;
        public int load;
        public Vector2 gridSize;
        public int gridSpaceInPixel;
    }
}
