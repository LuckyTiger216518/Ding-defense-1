using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
   
    //v�rdien af penge du f�r n�r du dr�ber fjender
    public int currencyValue = 10;   
    
    //skaber s� vi kan arbejde med moneymanager
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
        //Hvis objekt bliver destroyed skal den hente increase coden i moneymanageren og g�re det den kode g�r (s�tte currency op)
        //hvis money ikke er null s� skal den k�rer koden
        if (moneyManager != null)
        {
            moneyManager.IncreaseMoney(currencyValue);
        }
    }
}
