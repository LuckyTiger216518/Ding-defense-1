using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeight : MonoBehaviour
{
    
    private float height; // h�jde

    // S�t h�jde p� enemy
    public void SetHeight()
    {
        //s�ytter enemy height som y v�rdi
        height = transform.position.y;
    }

    private void Update()
    {
        //opdatere hvert frame h�jden
        SetHeight();    
    }
}

