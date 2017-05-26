using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HexagonBoard : MonoBehaviour
{

    [Inject]
    public IRootContext RootContext { get; set; }

    public GameObject imagePrefab;

    private Sprite[] sprites;

    // Use this for initialization
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("hexagonTerrain_sheet");
        int posX = 50;
        int posY = 50;
        int count = 0;
        int row = 1;
        int countId = 0;
        foreach (Sprite sprite in sprites)
        {
            GameObject tile = GameObject.Instantiate(imagePrefab);
            TileInfo info = tile.AddComponent<TileInfo>();
            info.id = countId++;
            DebugScript dScript = tile.GetComponent<DebugScript>();
            RootContext.Inject(dScript);
            tile.name = sprite.name;
            tile.transform.SetParent(transform);
            tile.transform.position = new Vector3(posX, posY, 0);
            Image image =tile.GetComponent<Image>();
            if(image != null)
            {
                image.sprite = sprite;
                image.enabled = true;
            }
            posX += 100;
            if (count == 11)
            {
                count = 0;
                row++;
                if(row % 2 == 0)
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

    // Update is called once per frame
    void Update()
    {

    }
}
