using UnityEngine;

public class Fish : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private string ItemName;
    [SerializeField] [Range(0.1f, 5)] float FishSpeed = 0.1f;
    [HideInInspector] public bool left;
    private GameObject Hook;
    private SpawnManager spawnManager;
    private InventoryManager inventoryManager;
    private FishingController fishingController;

    private State state;
    enum State 
    { 
        idle,
        interested,
        hooked
    }

    private void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        Hook = GameObject.Find("Hook");
        fishingController = GameObject.Find("MinigamePlayer").GetComponent<FishingController>();
    }

    private void Update()
    {
        StateHandler();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DestroyFish")
        {
            spawnManager.CurrentSpawnedAmount--;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Hook" && fishingController.occupied == false)
        {
            fishingController.occupied = true;
            state = State.hooked;
        }
        else if (collision.gameObject.tag == "Caught")
        {
            fishingController.occupied = false;
            spawnManager.CurrentSpawnedAmount--;
            inventoryManager.AddItem(1, ItemName);
            Destroy(gameObject);
        }
    }

    private void StateHandler()
    {
        switch (state)
        {
            case State.idle:
                gameObject.transform.Translate(-FishSpeed, 0, 0); //moves forward
                break;
            case State.interested:
                Interested();
                break;
            case State.hooked:
                Hooked();
                break;
        }
    }

    private void Interested()
    {
        Vector3 look = transform.InverseTransformPoint(Hook.transform.position); //looks towards hook
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, angle);

        float distance = Vector3.Distance(transform.position, Hook.transform.position);
        if ( distance < 1)
        {
            gameObject.transform.Translate(FishSpeed, 0, 0);       
        }
        else
        {
            gameObject.transform.Translate(FishSpeed, 0, 0);
        }
    }

    private void Hooked()
    {
        gameObject.transform.parent = Hook.transform;
    }
}
