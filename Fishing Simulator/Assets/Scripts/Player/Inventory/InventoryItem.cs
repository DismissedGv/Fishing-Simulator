using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IDataPersistence, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Components")]
    public string ItemName;
    public int amount;
    public int sellPrice;
    [SerializeField] private Button sellButton;
    [SerializeField] private GameObject sellText;

    public TextMeshProUGUI amountText;
    ShopManager shopManager;
    InventoryManager inventoryManager;
    GoldManager goldManager;

//-----------------------------------------------------------------------------------------------------Save and Load System
    public void LoadData(GameData data)
    {
        foreach (var field in typeof(GameData).GetFields())
        {
            if (field.Name == ItemName)
            {
                amount = (int)field.GetValue(data);
                UpdateUI();
                break;
            }
        }
    }
    public void SaveData(GameData data)
    {
        foreach (var field in typeof(GameData).GetFields())
        {
            if (field.Name == ItemName)
            {
                field.SetValue(data, amount);
                break;
            }
        }
    }
//-----------------------------------------------------------------------------------------------------

    public void Awake()
    {
        shopManager = GameObject.Find("Canvas").gameObject.transform.GetChild(0).GetComponent<ShopManager>();
        inventoryManager = GameObject.Find("Managers").GetComponent<InventoryManager>();
        goldManager = GameObject.Find("Managers").GetComponent<GoldManager>();

        sellText.GetComponentInChildren<TextMeshProUGUI>().text = "Sell: " + sellPrice + "gold";

        sellButton.onClick.AddListener(TaskOnClick);
    }

    public void UpdateUI()
    { 
        amountText.text = amount.ToString();  
    }

    public void OnEnable()
    {
        if (shopManager.isShopOpen)
        {
            sellButton.gameObject.SetActive(true);
        }
        else
        {
            sellButton.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (shopManager.isShopOpen)
        {
            sellText.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        sellText.SetActive(false);
    }

    void TaskOnClick(){
        if (amount >= 1)
        {
            amount --;
            inventoryManager.SellItem(1, ItemName);
            goldManager.EarnMoney(sellPrice);
        }   
	}
}
