using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private int MaximumSpawnAmount = 15;
    public int CurrentSpawnedAmount;
    public List<GameObject> Spawners;
    public List<GameObject> Fishes;

    [SerializeField] private float SpawnCooldown;

    //References
    private GameObject Canvas;
    [SerializeField] private GameObject Minigame;

    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
    }

    private void Update()
    {
        if (SpawnCooldown > 0) { SpawnCooldown -= Time.deltaTime; }

        if (CurrentSpawnedAmount < MaximumSpawnAmount && SpawnCooldown <= 0)
        {
            SpawnFish();
        }
    }

    private void SpawnFish()
    {
        SpawnCooldown = .1f;

        GameObject Prefab = RandomFish();
        GameObject RandomSpawner = Spawners[Random.Range(0, 2)];

        float x = RandomSpawner.transform.position.x;
        float y = RandomSpawner.transform.position.y + Random.Range(-300, 100);
        Vector2 SpawnPos = new Vector2(x, y); 

        GameObject fish = Instantiate(Prefab, SpawnPos, Quaternion.identity, Minigame.transform);
        if (RandomSpawner == Spawners[0])
        {
            fish.GetComponent<Fish>().left = true;
            fish.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        CurrentSpawnedAmount++;
    }

    private GameObject RandomFish()
    {
        int value = Random.Range(0, 100);

        if (value <= 60 )
        {
            return Fishes[0];
        }
        else if (value <= 75 )
        {
            return Fishes[1];
        }
        else if (value <= 90 )
        {
            return Fishes[2];
        }
        else if (value <= 100 )
        {
            return Fishes[3];
        }

        return null;
    }
}