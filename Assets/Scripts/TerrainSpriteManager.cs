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

    public SpriteKey[] spriteKey;

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
        foreach(SpriteKey key in spriteKey)
        {
            sprites.Add(key.type.ToString(), key.image);
        }
        //Sprite[] terrainSprites = Resources.LoadAll<Sprite>("hexagonTerrain_sheet");
        //foreach (Sprite sprite in terrainSprites)
        //{
        //    sprites.Add(sprite.name, sprite);
        //}
        EventManager.Raise(new ManagerStartedEvent(this));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite retrieveSprite(TerrainType type)
    {
        Sprite sprite;
        if (!sprites.TryGetValue(type.ToString(), out sprite))
        {
            Debug.LogError("sprite '" + type.ToString() + "' not found, returning default");
            sprite = defaultSprite;
        }
        return sprite;
    }
}
