using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    public int health = 100;  
    public TextMeshProUGUI healthText;  

    private void Update()
    {
        UpdateHealthText();
    }

    public void DecreaseHealth()
    {
        health--;

        if (health <= 0)
        {
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // Quit the application if not in the Unity Editor
            Application.Quit();
#endif
        }

        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
