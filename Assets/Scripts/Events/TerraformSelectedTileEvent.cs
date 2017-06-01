using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraformSelectedTileEvent : TileEvent {

    public TerrainType Terrain { get; protected set; }

    public TerraformSelectedTileEvent(TerrainType type, int id) : base(id)
    {
        Terrain = type;
    }
}
