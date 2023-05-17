using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int startingMoney = 100;  // The initial money value
    public int currentMoney;       // The current money value
    public TMP_Text moneyText;  // Reference to the UI Text component displaying the money value

    private void Start()
    {
        currentMoney = startingMoney;
        UpdateMoneyUI();
    }
    public void IncreaseMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
    }

    public void DecreaseMoney(int amount)
    {
        currentMoney -= amount;
        UpdateMoneyUI();
    }

    private void UpdateMoneyUI()
    {
        moneyText.text = "$" + currentMoney.ToString();  // Format the money value as desired
    }
}
