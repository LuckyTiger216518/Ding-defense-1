using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //laver 2 intergers som skal bruges til at bestemme fjenders liv.
    public int maxHealth = 5;
    public int currentHealth;
   
    //v�rdien af penge du f�r n�r du dr�ber fjender
    public int currencyValue = 10;   
    
    //skaber s� vi kan arbejde med moneymanager
    public MoneyManager moneyManager;

    void Start()
    {
        // s�tter startv�rdien for fjendernes hp til maxHealth
        currentHealth = maxHealth;

        //finder manageren i projektet (vores gamemanager)
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    //TakeDamage f�r fjenderne til at tage skade og hvis deres liv bliver 0 eller mindre vil de d� (gameobjectet bliver slettet)
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
