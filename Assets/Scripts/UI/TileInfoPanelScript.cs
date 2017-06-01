using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInfoPanelScript : MonoBehaviour
{

    [Inject]
    public IEventManager EventManager { get; set; }

    public Text nameText;

    public Text typeText;

    // Use this for initialization
    void Start()
    {
        EventManager.AddListener<SelectionChangeEvent>(HandleSelectionChange);
        EventManager.AddListener<TerraformSelectedTileEvent>(HandleTerraformSelectedTile);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleSelectionChange(SelectionChangeEvent e)
    {
        if (e.Selection != null)
        {
            nameText.text = e.Selection.name;

            TileInfo info = e.Selection.GetComponent<TileInfo>();
            if (info != null)
            {
                typeText.text = info.type.ToString();
            }
        }
    }

    private void HandleTerraformSelectedTile(TerraformSelectedTileEvent e)
    {
        typeText.text = e.Terrain.ToString();
    }
}
