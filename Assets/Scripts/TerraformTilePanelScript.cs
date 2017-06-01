using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerraformTilePanelScript : MonoBehaviour
{

    [Inject]
    public IEventManager EventManager { get; set; }

    [Inject]
    public ISelectionManager SelectionManager { get; set; }

    [Inject]
    public ITerrainSpriteManager TerrainSpriteManager { get; set; }

    public Image image;

    public Text text;

    private TerrainType terrain;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setTerrainType(TerrainType type)
    {
        this.terrain = type;
        text.text = type.ToString();
        image.sprite = TerrainSpriteManager.retrieveSprite(terrain);
    }

    public void clicked()
    {
        if (SelectionManager.Selected != null)
        {
            //Try and get the image
            TileInfo info = SelectionManager.Selected.GetComponent<TileInfo>();
            if (info != null)
            {
                EventManager.Raise(new TerraformSelectedTileEvent(terrain, info.id));
            }
        }
    }
}
