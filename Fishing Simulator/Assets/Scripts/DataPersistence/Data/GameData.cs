using UnityEngine;

[System.Serializable]

public class GameData
{
    [Header("Player Settings")]
    public float currentHealth;
    public float maxHealth;
    public int playerMoney;
    public Vector3 spawnPoint;

    [Header("Player Statistics")]
    public int deathCount;
    public int percentageToCollect;
    public int percentageCollected;

    [Header("System")]
    public long lastUpdated;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        this.maxHealth = 100f;
        this.currentHealth = 100f;
        this.playerMoney = 0;

        spawnPoint = Vector3.zero;

        this.deathCount = 0;
        percentageToCollect = 100;
        percentageCollected = 0;
    }

    public int GetPercentageComplete()
    {
        // ensure we don't divide by 0 when calculating the percentage
        int percentageCompleted = -1;
        if (percentageToCollect != 0)
        {
            percentageCompleted = (percentageCollected * 100 / percentageToCollect);
        }

        return percentageCompleted;
    }
}
