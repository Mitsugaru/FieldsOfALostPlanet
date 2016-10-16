using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using strange.extensions.mediation.impl;

public class UIPanelManager : View, IUIPanelManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    [Inject]
    public ISelectionManager SelectionManager { get; set; }

    [Inject]
    public ICropManager CropManager { get; set; }

	public GameObject TileInfoPanel;

    private Slider slider;

    // Use this for initialization
    protected override void Start()
    {
        slider = TileInfoPanel.GetComponentInChildren<Slider>();
        EventManager.AddListener<TickElapsedEvent>(HandleTickElapsed);
    }

    // Update is called once per frame
    void Update()
    {
		TileInfoPanel.SetActive(SelectionManager.Selected != null);
    }

    private void HandleTickElapsed(TickElapsedEvent e)
    {
        slider.value = CropManager.GetCropInfo(null).Growth;
    }
}
