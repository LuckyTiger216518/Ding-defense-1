using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeight : MonoBehaviour
{
    
    private float height; // højde

    // Sæt højde på enemy
    public void SetHeight()
    {
        //sæytter enemy height som y værdi
        height = transform.position.y;
    }

    private void Update()
    {
        //opdatere hvert frame højden
        SetHeight();    
    }
}

