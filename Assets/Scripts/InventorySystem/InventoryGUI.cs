using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Peixi
{
    public class InventoryGUI : MonoBehaviour
    {
        public GameObject gridPrefab;

        public Transform grids_tran;
        private List<ControlGridContent> gridScripts = new List<ControlGridContent>();
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 8; i++)
            {
                var grid = GameObject.Instantiate(gridPrefab, grids_tran);
                grid.transform.name = i.ToString();

                var controlGrid = grid.GetComponent<ControlGridContent>();
                controlGrid.gridSequence = i;
                controlGrid.ClearGridContent();

                gridScripts.Add(controlGrid);
               
            }

            InterfaceManager.manager.OnInventorySystemActived
                .Subscribe(x =>
                {
                    x.OnInventoryChanged.Subscribe(y =>
                    {
                        var gridSequence = y.NewValue.Position;
                        var theHandledGrid = gridScripts[gridSequence];

                        theHandledGrid.SetGridContent(y.NewValue.Name, y.NewValue.Amount);
                    });
                });
        }
    }
}
