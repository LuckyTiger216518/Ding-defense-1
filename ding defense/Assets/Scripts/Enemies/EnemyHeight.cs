using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeight : MonoBehaviour
{
    
    private float height; // højde

    // Sæt højde på enemy
    public void SetHeight()
    {

        height = transform.position.y;
    }
    public float GetHeight()
    {
        return height;
    }

    private void Update()
    {
        SetHeight();    
    }
}

