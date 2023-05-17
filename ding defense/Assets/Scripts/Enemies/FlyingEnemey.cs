using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    //laver 2 intergers som skal bruges til at bestemme fjenders liv.
    public int maxHealth = 5;
    public int currentHealth;

    void Start()
    {
        // s�tter startv�rdien for fjendernes hp til maxHealth
        currentHealth = maxHealth;
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
}
