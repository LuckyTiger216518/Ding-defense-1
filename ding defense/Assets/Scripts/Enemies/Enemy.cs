using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
   
    //værdien af penge du får når du dræber fjender
    public int currencyValue = 10;   
    
    //skaber så vi kan arbejde med moneymanager
    public MoneyManager moneyManager;

    void Start()
    {
        currentHealth = maxHealth;

        //finder manageren i projektet (vores gamemanager)
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            HealthManager healthManager = other.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.DecreaseHealth();
            }
        }
    }
    private void OnDestroy()
    {
        //Hvis objekt bliver destroyed skal den hente increase coden i moneymanageren og gøre det den kode gør (sætte currency op)
        //hvis money ikke er null så skal den kører koden
        if (moneyManager != null)
        {
            moneyManager.IncreaseMoney(currencyValue);
        }
    }
}
