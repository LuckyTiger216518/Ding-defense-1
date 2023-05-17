using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//bruger TMPro for at f� adgang til text i panelet
public class MoneyManager : MonoBehaviour
{

    //s�tter start v�rdi af penge 
    public int startingMoney = 100;  

    //s�tter s� vi kan opdatere hvor mange penge vi har efter andre koders brug
    public int currentMoney;       

    //henter UI s�dan den er koblet til scriptet
    public TMP_Text moneyText;  

    private void Start()
    {
        //S�tter s�dan vi starter med den m�ngde penge vi har og opdatere UI p� det
        currentMoney = startingMoney;
        UpdateMoneyUI();
    }
    public void IncreaseMoney(int amount)
    {
        //g�r s�dan at vi kan f� flere penge ind ved brug af den her kode hver gang vi referer hertil. og opdatere UI
        currentMoney += amount;
        UpdateMoneyUI();
    }

    public void DecreaseMoney(int amount)
    {
        //g�r det modsatte af koden over og opdatere UI
        currentMoney -= amount;
        UpdateMoneyUI();
    }

    private void UpdateMoneyUI()
    {
        //s�tter s�dan at den selv skriver i UI v�rdien af penge vi har s�dan det bliver nemmere at holde styr p�
        moneyText.text = "$" + currentMoney.ToString();  
    }
}
