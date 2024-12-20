using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private GameObject Inventory;

    [SerializeField] private PlayerInputMap inputManager;
    public bool isInventoryOpen;

    private void Awake()
    {
        inputManager = new PlayerInputMap();
    }

     private void OnEnable()
    {
        inputManager.Enable();
    }

     private void Update()
    {
        bool isInventoryKeyHeld = inputManager.Player.Inventory.IsPressed();

        if (isInventoryKeyHeld)
        {
            Inventory.SetActive(true);
        }
        else
        {
            Inventory.SetActive(false);
            List<GameObject> items = new List<GameObject>(GameObject.FindGameObjectsWithTag("InventoryItem"));
        }
    }

    public void AddItem(int amount, string ItemName)
    {
        foreach (var item in items)
        {
            if (item.GetComponent<InventoryItem>().ItemName == ItemName)
            {
                item.GetComponent<InventoryItem>().amount += amount;
                item.GetComponent<InventoryItem>().UpdateUI();
                UpdateUI(item);
                break;
            }
        }   
    }

    public void SellItem(int amount, string ItemName)
    {
        foreach (var item in items)
        {
            if (item.GetComponent<InventoryItem>().ItemName == ItemName)
            {
                item.GetComponent<InventoryItem>().amount -= amount;
                item.GetComponent<InventoryItem>().UpdateUI();
                UpdateUI(item);
                break;
            }
        }   
    }

    private void UpdateUI(GameObject item)
    {
        if (item.GetComponent<InventoryItem>().amount <= 0)
        {
            item.SetActive(false);
        }
        else
        {
            item.SetActive(true);
        }
    }
}