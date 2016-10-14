using UnityEngine;
using System.Collections.Generic;
using strange.extensions.mediation.impl;

public class GridManager : View, IGridManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    public GameObject SpritePlanePrefab;

    public int size = 5;

	public Sprite[] flowers;

    private Dictionary<Vector2, GridCell> cells = new Dictionary<Vector2, GridCell>();

    // Use this for initialization
    protected override void Start()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
				GameObject plane = Instantiate(SpritePlanePrefab);
				plane.transform.position = new Vector3(i * 5, 0, j * 5);

				SpriteRenderer spriteRenderer = plane.GetComponentInChildren<SpriteRenderer>();
				if(spriteRenderer != null)
				{
					spriteRenderer.sprite = flowers[Random.Range(0, flowers.Length)];
				}

				GridCell cell = new GridCell(plane);
				cells.Add(new Vector2(i, j), cell);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnDestroy()
    {
		foreach(GridCell cell in cells.Values) {
			Destroy(cell.Cell);
		}
		cells.Clear();
    }
}
