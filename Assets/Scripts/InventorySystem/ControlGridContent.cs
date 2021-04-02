using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlGridContent :MonoBehaviour
{
    public Text nameLabel;
    public Text amountLabel;
    public int gridSequence;

    public void SetGridContent(string name,int amount)
    {
        nameLabel.text = name;
        amountLabel.text = amount.ToString();

        if (amount == 0)
        {
            ClearGridContent();
        }
    }
    public void ClearGridContent()
    {
        nameLabel.text = "";
        amountLabel.text = "";
    }
}
