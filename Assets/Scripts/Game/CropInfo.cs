using UnityEngine;
using System.Collections;

public class CropInfo
{

    private int health = 0;
    public int Health
    {
        get
        {
            return health;
        }
    }
    private int maxHealth = 100;
    private int growth = 0;
    public int Growth
    {
        get
        {
            return growth;
        }
    }
    private int maxGrowth = 100;
    private int quality = 0;
    public int Quality
    {
        get
        {
            return quality;
        }
    }
    private int maxQuality = 100;

    public void SetHealth(int value)
    {
        health = Bound(value, 0, maxHealth);
    }

    public void SetGrowth(int value)
    {
		growth = Bound(value, 0, maxGrowth);
    }

    public void SetQuality(int value)
    {
		quality = Bound(value, 0, maxQuality);
    }

	private int Bound(int value, int min, int max) {
		int v = value;
		if (v < min)
        {
            v = min;
        }
        else if (v > max)
        {
            v = max;
        }
		return v;
	}
}
