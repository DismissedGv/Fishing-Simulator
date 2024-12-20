using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour, IDataPersistence
{
    public int gold;
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
        UpdateUI();
    }

//-----------------------------------------------------------------------------------------------------Save and Load System
    public void LoadData(GameData data)
    {
        this.gold = data.playerMoney;
        UpdateUI();
    }
    public void SaveData(GameData data)
    {
        data.playerMoney = this.gold;
    }
//-----------------------------------------------------------------------------------------------------

    public void EarnMoney(int earned)
    {
        gold += earned;
        UpdateUI();
    }

    public void WasteMoney(int wasted)
    {
        gold -= wasted;
        UpdateUI();
    }

    private void UpdateUI()
    {
        goldText.text = "Gold: " + gold;
    }
}