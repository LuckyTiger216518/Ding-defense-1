using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pathfinding : MonoBehaviour
{
    // Det er en array af transforms der repr�sentere de waypoint som "enemiesne" ville bev�ge sig p�
    public Transform[] waypoints;
    // Farten som "enemiesne" bev�ger sig mod waypointene
    public float moveSpeed = 5f;
    // index af det waypoint "enemien" bev�ger sig mod
    private int waypointIndex = 0;
    void Update()
    {
        // hvis der stadig er waypoints at komme hentil
        if (waypointIndex < waypoints.Length)
        {   
            // bev�ge "enemien" mod det nuv�rende waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

            // hvis "enemien" er n�et til nuv�rende waypoint s� skift til n�ste waypoint
            if (transform.position == waypoints[waypointIndex].position)
            {
                waypointIndex++;
            }
        }
    }
}