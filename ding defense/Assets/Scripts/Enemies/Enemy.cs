using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public int currencyValue = 10;               
    public MoneyManager moneyManager;

    void Start()
    {
        currentHealth = maxHealth;
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (moneyManager != null)
        {
            moneyManager.IncreaseMoney(currencyValue);
        }
    }
}
