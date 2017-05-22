using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Class that manages the loading and referencing of terrain-based sprite images
/// </summary>
public class TerrainSpriteManager : MonoBehaviour, ITerrainSpriteManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    public Sprite defaultSprite;
    /// <summary>
    /// Dictionary of sprites
    /// </summary>
    private IDictionary<string, Sprite> sprites;

    /// <summary>
    /// Default Constructor
    /// </summary>
    public TerrainSpriteManager()
    {
        sprites = new Dictionary<string, Sprite>();
    }

    // Use this for initialization
    void Start()
    {
        Sprite[] terrainSprites = Resources.LoadAll<Sprite>("hexagonTerrain_sheet");
        foreach (Sprite sprite in terrainSprites)
        {
            Debug.Log("Registered " + sprite.name);
            sprites.Add(sprite.name, sprite);
        }
        EventManager.Raise(new ManagerStartedEvent(this));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite retrieveSprite(string name)
    {
        Debug.Log("Requested " + name);

        Sprite sprite;
        if (!sprites.TryGetValue(name, out sprite))
        {
            Debug.Log("not found, returning default");
            sprite = defaultSprite;
        }
        return sprite;
    }
}
