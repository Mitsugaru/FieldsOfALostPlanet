using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPanelScript : MonoBehaviour
{

    [Inject]
    public IRootContext RootContext { get; set; }

    [Inject]
    public IEventManager EventManager { get; set; }

    [Inject]
    public ITerrainSpriteManager TerrainSpriteManager { get; set; }

    public GameObject tileButtonPrefab;

    public string[] tileIds;

    // Use this for initialization
    void Start()
    {
        EventManager.AddListener<ManagerStartedEvent>(HandleManagerStarted);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleManagerStarted(ManagerStartedEvent e)
    {
        if (e.Manager.Equals(TerrainSpriteManager))
        {
            foreach (string tileId in tileIds)
            {
                GameObject tileButton = GameObject.Instantiate(tileButtonPrefab);
                TerrainTilePanelScript tileScript = tileButton.GetComponent<TerrainTilePanelScript>();
                tileScript.Sprite = TerrainSpriteManager.retrieveSprite(tileId);
                tileScript.setTerrainName(tileId);
                RootContext.Inject(tileScript);
                tileButton.transform.SetParent(transform);
            }
            EventManager.AddListener<ManagerStartedEvent>(HandleManagerStarted);
        }
    }
}
