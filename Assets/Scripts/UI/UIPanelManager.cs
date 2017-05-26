using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using strange.extensions.mediation.impl;

public class UIPanelManager : View, IUIPanelManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    [Inject]
    public ITileManager TileManager { get; set; }

    [Inject]
    public ICropManager CropManager { get; set; }

    [Inject]
    public ISelectionManager SelectionManager { get; set; }

    public GameObject TileInfoPanel;

    public GameObject TerrainPanel;

    private Slider slider;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        slider = TileInfoPanel.GetComponentInChildren<Slider>();
        EventManager.AddListener<TickElapsedEvent>(HandleTickElapsed);
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

    private void HandleTickElapsed(TickElapsedEvent e)
    {
        if (slider != null)
        {
            slider.value = CropManager.GetCropInfo(null).Growth;
        }
    }
}
