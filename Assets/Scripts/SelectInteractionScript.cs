using UnityEngine;
using System.Collections;

public class SelectInteractionScript : MonoBehaviour
{

    [Inject]
    public IEventManager EventManager { get; set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DebugInteraction()
    {
        Debug.Log("interacted with " + name);
        EventManager.Raise(new SelectionEvent(gameObject));
    }
}
