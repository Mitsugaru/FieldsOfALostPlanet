using UnityEngine;

public class GridCell
{

    private GameObject cell;
    public GameObject Cell
    {
        get
        {
            return cell;
        }
    }

    public GridCell(GameObject cell)
    {
        this.cell = cell;
    }
}
