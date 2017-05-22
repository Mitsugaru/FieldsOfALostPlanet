using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionEvent : GameEvent
{

    public GameObject Selected { get; protected set; }

    public SelectionEvent(GameObject selection)
    {
        Selected = selection;
    }
}
