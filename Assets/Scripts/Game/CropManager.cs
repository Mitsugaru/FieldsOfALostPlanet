using UnityEngine;
using strange.extensions.mediation.impl;

public class CropManager : View, ICropManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

	private CropInfo info = new CropInfo();

    // Use this for initialization
    protected override void Start()
    {
        EventManager.AddListener<TickElapsedEvent>(HandleTickElapsed);
    }

    // Update is called once per frame
    void Update()
    {

    }

	public CropInfo GetCropInfo(GridCell cell)
	{
		return info;
	}

    private void HandleTickElapsed(TickElapsedEvent e)
    {
		info.SetGrowth(info.Growth + 1);
    }
}
