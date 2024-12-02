using UnityEngine;

[System.Serializable]

public class GameData
{
    [Header("Player Status")]
    public int playerMoney;
    public int fishCaught;
    public Vector3 spawnPoint;

    [Header("Inventory")]
    public int fish1;
    public int fish2;
    public int fish3;
    public int fish4;

    public int percentageToCollect;
    public int percentageCollected;

    [Header("System")]
    public long lastUpdated;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        this.playerMoney = 0;
        this.fishCaught = 0;
        this.fish1 = 0;
        this.fish2 = 0;
        this.fish3 = 0;
        this.fish4 = 0;

        spawnPoint = Vector3.zero;
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
