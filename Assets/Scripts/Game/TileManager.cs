using UnityEngine;
using System.Collections.Generic;
using System;

public class TileManager : MonoBehaviour, ITileManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    [Inject]
    public ISelectionManager SelectionManager { get; set; }

    private IDictionary<int, TileInfo> tiles = new Dictionary<int, TileInfo>();

    private int atomicId = 0;

    private readonly Array terrainValues = Enum.GetValues(typeof(TerrainType));

    private readonly System.Random random = new System.Random();

    // Use this for initialization
    void Start()
    {
        EventManager.AddListener<TerraformSelectedTileEvent>(HandleTerraformSelectedTile);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public TileInfo getTileInfo(int tileId)
    {
        TileInfo info = null;
        if (!tiles.TryGetValue(tileId, out info))
        {
            Debug.LogError("tile info '" + tileId + "' not found, returning null");
        }
        return info;
    }

    public TileInfo generateTile(GameObject tile)
    {
        TileInfo info = tile.AddComponent<TileInfo>();
        info.id = atomicId++;

        TerrainType randomType = (TerrainType)terrainValues.GetValue(random.Next(terrainValues.Length));
        info.type = randomType;

        TileAttributes attributes = new TileAttributes();

        attributes.terraformable = true;

        switch (randomType)
        {
            case TerrainType.DIRT:
                attributes.farmable = true;
                break;
            case TerrainType.GRASS:
                attributes.farmable = true;
                break;
            default:
                break;
        }
        info.attributes = attributes;
        info.farmland = new FarmlandInfo();

        tiles.Add(info.id, info);

        return info;
    }

    private void HandleTerraformSelectedTile(TerraformSelectedTileEvent e)
    {
        //Update our data reference
        TileInfo info;
        if (tiles.TryGetValue(e.TileId, out info))
        {
            info.type = e.Terrain;
        }
    }
}
