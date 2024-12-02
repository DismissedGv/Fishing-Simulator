using TMPro;
using UnityEngine;

public class InventoryItem : MonoBehaviour, IDataPersistence
{
    [Header("Components")]
    public string ItemName;
    public int amount;

    public TextMeshProUGUI amountText;

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

    public void UpdateUI()
    { 
        amountText.text = amount.ToString();  
    }
}
