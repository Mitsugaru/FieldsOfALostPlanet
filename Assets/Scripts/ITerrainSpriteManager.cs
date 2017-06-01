using UnityEngine;
using System.Collections;

public interface ITerrainSpriteManager {

    /// <summary>
    /// Get the sprite for the given name
    /// </summary>
    /// <param name="TerrainType">terrain type</param>
    /// <returns>Sprite reference, otherwise null</returns>
    Sprite retrieveSprite(TerrainType type);
}
