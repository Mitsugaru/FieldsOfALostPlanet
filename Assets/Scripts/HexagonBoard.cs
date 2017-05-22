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
        sprites = Resources.LoadAll<Sprite>("hexagonAll_sheet");
        int posX = 30;
        int posY = 30;
        int count = 0;
        int row = 1;
        foreach (Sprite sprite in sprites)
        {
            GameObject tile = GameObject.Instantiate(imagePrefab);
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
            posX += 60;
            if (count == 15)
            {
                count = 0;
                row++;
                if(row % 2 == 0)
                {
                    posX = 60;
                }
                else
                {
                    posX = 30;
                }
                posY += 45;
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
