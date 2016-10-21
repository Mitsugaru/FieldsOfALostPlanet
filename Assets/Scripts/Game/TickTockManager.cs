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

    public int ticksPerDay = 60;

    public int daysPerSeason = 30;

    public GameObject sun;

    public Vector3 initialRotation = Vector3.zero;

    private float timeSinceLastTick = 0;
    private int currentDay = 0;
    private int ticksThisDay = 0;
    private float pauseTime = 0;
    private int tickCount = 0;

    private Quaternion previousSunTickRotation;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        sun.transform.eulerAngles = initialRotation;
        previousSunTickRotation = sun.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            float current = Time.time;
            float deltaTime = current - pauseTime - timeSinceLastTick;
            //Handle sun day / night
            float lerpDiff = Mathf.Min(deltaTime / secondsPerTick, 1.0f);
            Quaternion sunQuat = Quaternion.Euler(TargetSunRotation());
            sun.transform.rotation = Quaternion.Lerp(previousSunTickRotation, sunQuat, lerpDiff);

            if (deltaTime >= secondsPerTick)
            {
                tickCount++;
                timeSinceLastTick = current;
                previousSunTickRotation = sunQuat;
                pauseTime = 0;
                //Calculate day passage
                ticksThisDay++;
                if (ticksThisDay >= ticksPerDay)
                {
                    ticksThisDay = 0;
                    currentDay++;
                    //TODO send out an event that a day has passed
                }

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

    private Vector3 TargetSunRotation()
    {
        Vector3 sunEuler = Vector3.zero;
        float seasonRatio = ((float)(currentDay) / (float)daysPerSeason);
        sunEuler.y = seasonRatio * 360.0f;

        int futureTick = ticksThisDay + 1;
        if (futureTick >= ticksPerDay)
        {
            futureTick = 0;
        }

        float dayRatio = (float)futureTick / (float)ticksPerDay;
        sunEuler.x = (dayRatio * 360.0f);

        return sunEuler;
    }
}
