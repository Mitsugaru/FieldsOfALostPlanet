using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainTilePanelScript : MonoBehaviour
{

    [Inject]
    public ISelectionManager SelectionManager { get; set; }

    public Image image;

    public Text text;

    private Sprite sprite;
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
        set
        {
            sprite = value;
            image.sprite = value;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setTerrainName(string name)
    {
        text.text = name;
    }

    public void clicked()
    {
        if (SelectionManager.Selected != null)
        {
            //Try and get the image
            Image image = SelectionManager.Selected.GetComponent<Image>();
            if (image != null)
            {
                image.sprite = Sprite;
            }
        }
    }
}
