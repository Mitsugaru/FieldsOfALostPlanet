using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionChangeEvent : GameEvent {
    
    public GameObject Selection
    {
        get; protected set;
    }

    public SelectionChangeEvent(GameObject selection)
    {
        this.Selection = selection;
    }
}
