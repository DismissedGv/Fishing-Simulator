using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] string itemName;
    [SerializeField] float price;
    [SerializeField] int purchaseAmount;
    [SerializeField] int StockAmount;
    

    private Button purchaseButton;
    private Image itemImage;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();

        purchaseButton = transform.GetComponentInChildren<Button>();
        itemImage = transform.GetChild(0).GetComponent<Image>();

        purchaseButton.onClick.AddListener(BuyItem); 
    }

    private void BuyItem()
    {
        if (StockAmount >= purchaseAmount)
        {
            inventoryManager.AddItem(purchaseAmount, itemName);
            Debug.Log("Bought " + itemName + " for " + price);
            StockAmount -= purchaseAmount;
        }
        else
        {
            purchaseButton.interactable = false;
            itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 0.50f);
        }
    }
}
