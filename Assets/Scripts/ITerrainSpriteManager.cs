using UnityEngine;
using System.Collections;

public interface ITerrainSpriteManager {

    /// <summary>
    /// Get the sprite for the given name
    /// </summary>
    /// <param name="name">Sprite name</param>
    /// <returns>Sprite reference, otherwise null</returns>
    Sprite retrieveSprite(string name);
}
