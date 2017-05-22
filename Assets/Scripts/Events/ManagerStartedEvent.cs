using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStartedEvent : GameEvent
{

    public Object Manager { get; protected set; }

    public ManagerStartedEvent(Object manager)
    {
        Manager = manager;
    }
}
