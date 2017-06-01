using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HexagonBoard : MonoBehaviour
{

    [Inject]
    public IRootContext RootContext { get; set; }

    [Inject]
    public ITileManager TileManager { get; set; }

    [Inject]
    public IEventManager EventManager { get; set; }

    [Inject]
    public ITerrainSpriteManager TerrainSpriteManager { get; set; }

    public GameObject imagePrefab;

    public int startingCount = 30;

    public int offsetX = 0;

    public int offsetY = 0;

    // Use this for initialization
    void Start()
    {
        EventManager.AddListener<ManagerStartedEvent>(HandleManagerStarted);
        EventManager.AddListener<TerraformSelectedTileEvent>(HandleTerraformSelectedTile);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleManagerStarted(ManagerStartedEvent e)
    {
        int posX = 50;
        int posY = 50;
        int count = 0;
        int row = 1;
        for (int i = 0; i < startingCount; i++)
        {
            GameObject tile = GameObject.Instantiate(imagePrefab);
            TileInfo info = TileManager.generateTile(tile);
            SelectInteractionScript dScript = tile.GetComponent<SelectInteractionScript>();
            RootContext.Inject(dScript);
            tile.name = "Tile-" + info.id;
            tile.transform.SetParent(transform);
            tile.transform.position = new Vector3(posX + offsetX, posY + offsetY, 0);
            Image image = tile.GetComponent<Image>();
            Sprite sprite = TerrainSpriteManager.retrieveSprite(info.type);
            if (image != null && sprite != null)
            {
                image.sprite = sprite;
                image.enabled = true;
            }

            posX += 100;
            if (count == 11)
            {
                count = 0;
                row++;
                if (row % 2 == 0)
                {
                    posX = 100;
                }
                else
                {
                    posX = 50;
                }
                posY += 74;
            }
            else
            {
                count++;
            }
        }
    }

    private void HandleTerraformSelectedTile(TerraformSelectedTileEvent e)
    {
        // Update image to what we're going to terraform to
        TileInfo info = TileManager.getTileInfo(e.TileId);
        if(info != null)
        {
            Image image = info.gameObject.GetComponent<Image>();
            Sprite sprite = TerrainSpriteManager.retrieveSprite(e.Terrain);
            if (image != null && sprite != null)
            {
                image.sprite = sprite;
                image.enabled = true;
            }
        }
    }
}
