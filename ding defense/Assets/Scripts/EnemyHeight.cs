using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeight : MonoBehaviour
{
    
    private float height; // h�jde

    // S�t h�jde p� enemy
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

