using UnityEngine;
using strange.extensions.mediation.impl;

public class SelectionManager : View, ISelectionManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    public GameObject Selected { get; protected set; }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        EventManager.AddListener<SelectionEvent>(HandleSelection);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchSupported)
        //{
        //    HandleTouch();
        //}
        //else
        //{
        //    HandleMouseAndKeyboard();
        //}
    }

    private void HandleSelection(SelectionEvent e)
    {
        if (Selected == null)
        {
            Selected = e.Selected;
        }
        else if (Selected != e.Selected)
        {
            Selected = e.Selected;
        }
    }

    void HandleMouseAndKeyboard()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Selected = DetectTileTerrainHit(ray);
        }
    }

    void HandleTouch()
    {
        // Look for all fingers
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // -- Tap: quick touch & release
            // ------------------------------------------------
            if (touch.phase == TouchPhase.Ended && touch.tapCount == 1)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Selected = DetectTileTerrainHit(ray);
            }
        }
    }

    GameObject DetectTileTerrainHit(Ray ray)
    {
        GameObject target = null;

        RaycastHit[] hits = Physics.RaycastAll(ray, float.MaxValue, LayerMask.GetMask("TileTerrain"));
        for (int i = 0; i < hits.Length; i++)
        {
            target = hits[i].transform.gameObject;
        }

        return target;
    }
}
