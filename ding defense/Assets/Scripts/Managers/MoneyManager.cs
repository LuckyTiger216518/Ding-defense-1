using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//bruger TMPro for at få adgang til text i panelet
public class MoneyManager : MonoBehaviour
{

    //sætter start værdi af penge 
    public int startingMoney = 100;  

    //sætter så vi kan opdatere hvor mange penge vi har efter andre koders brug
    public int currentMoney;       

    //henter UI sådan den er koblet til scriptet
    public TMP_Text moneyText;  

    private void Start()
    {
        //Sætter sådan vi starter med den mængde penge vi har og opdatere UI på det
        currentMoney = startingMoney;
        UpdateMoneyUI();
    }
    public void IncreaseMoney(int amount)
    {
        //gør sådan at vi kan få flere penge ind ved brug af den her kode hver gang vi referer hertil. og opdatere UI
        currentMoney += amount;
        UpdateMoneyUI();
    }

    public void DecreaseMoney(int amount)
    {
        //gør det modsatte af koden over og opdatere UI
        currentMoney -= amount;
        UpdateMoneyUI();
    }

    private void UpdateMoneyUI()
    {
        //sætter sådan at den selv skriver i UI værdien af penge vi har sådan det bliver nemmere at holde styr på
        moneyText.text = "$" + currentMoney.ToString();  
    }
}
