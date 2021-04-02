using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peixi
{
    public struct InventoryGridData
    {
        public string Name
        {
            set { m_name = value; }
            get => m_name;
        }
        public int Amount
        {
            set { m_amount = value; }
            get => m_amount;
        }
        public int Position => m_posotion;
        public bool IsEmpty
        {
            set { m_isEmpty = value; }
            get => m_isEmpty;
        }

        private string m_name;
        private int m_amount;
        private int m_posotion;
        private bool m_isEmpty;

        public InventoryGridData(int position, string name, int amount, bool isEmpty)
        {
            m_name = name;
            m_amount = amount;
            m_posotion = position;
            m_isEmpty = isEmpty;
        }
    }
}
