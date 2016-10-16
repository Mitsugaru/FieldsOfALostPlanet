using UnityEngine;
using strange.extensions.mediation.impl;

public class TickTockManager : View, ITickTockManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    public bool pause = false;
    public bool Paused
    {
        get
        {
            return pause;
        }
    }

    public int secondsPerTick = 3;

    private float timeSinceLastTick = 0;
    private float pauseTime = 0;
    private int tickCount = 0;

    // Use this for initialization
    protected override void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            float current = Time.time;
            float deltaTime = current - pauseTime - timeSinceLastTick;
            if (deltaTime >= secondsPerTick)
            {
                tickCount++;
                timeSinceLastTick = current;
                pauseTime = 0;
                EventManager.Raise(new TickElapsedEvent());
            }
        }
    }

    public void SetPaused(bool state)
    {
        if (state)
        {
            pauseTime = Time.time;
        }
        else
        {
            pauseTime = Time.time - pauseTime;
        }
        pause = state;
    }
}
