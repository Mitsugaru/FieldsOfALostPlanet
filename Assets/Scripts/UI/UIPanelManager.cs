using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using strange.extensions.mediation.impl;

public class UIPanelManager : View, IUIPanelManager
{

    [Inject]
    public ITileManager TileManager { get; set; }

    [Inject]
    public ISelectionManager SelectionManager { get; set; }

    public GameObject TerrainPanel;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectionManager.Selected != null)
        {
            //Set terrain panel info here
            TerrainPanel.SetActive(true);
        }
        else
        {
            TerrainPanel.SetActive(false);
        }
    }
}
