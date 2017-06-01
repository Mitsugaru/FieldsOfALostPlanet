using UnityEngine;
using System.Collections;

public interface ITileManager {

    TileInfo getTileInfo(int tileId);

    TileInfo generateTile(GameObject tile);
}
