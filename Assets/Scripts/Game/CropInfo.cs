using UnityEngine;
using System.Collections;

[System.Serializable]
public class CropInfo
{

    private string name;
    public string Name
    {
        get
        {
            return name;
        }
    }

    private Sprite sprite;
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

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

    // The following are only for reporting to Unity to visualize what data is there in the Inspector
    public string reportName = string.Empty;
    public Sprite reportSprite;
    public int reportHealth = 0;
    public int reportGrowth = 0;
    public int reportQuality = 0;

    public void SetName(string name)
    {
        this.name = name;
        reportName = name;
    }

    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
        reportSprite = sprite;
    }

    public void SetHealth(int value)
    {
        health = Bound(value, 0, maxHealth);
        reportHealth = health;
    }

    public void SetGrowth(int value)
    {
        growth = Bound(value, 0, maxGrowth);
        reportGrowth = growth;
    }

    public void SetQuality(int value)
    {
        quality = Bound(value, 0, maxQuality);
        reportQuality = quality;
    }

    private int Bound(int value, int min, int max)
    {
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
