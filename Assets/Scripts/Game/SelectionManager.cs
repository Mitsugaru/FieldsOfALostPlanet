using UnityEngine;
using strange.extensions.mediation.impl;

public class SelectionManager : View, ISelectionManager
{

    private GameObject selected;
    public GameObject Selected
    {
        get
        {
            return selected;
        }
    }

    // Use this for initialization
    protected override void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchSupported)
        {
            HandleTouch();
        }
        else
        {
            HandleMouseAndKeyboard();
        }
    }

    void HandleMouseAndKeyboard()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            selected = DetectTileTerrainHit(ray);
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
                selected = DetectTileTerrainHit(ray);
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
