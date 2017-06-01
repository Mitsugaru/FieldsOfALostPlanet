using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEvent : GameEvent {

	public int TileId { get; protected set; }

    public TileEvent(int id)
    {
        TileId = id;
    }
}
