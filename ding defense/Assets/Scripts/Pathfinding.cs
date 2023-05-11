using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pathfinding : MonoBehaviour
{
    // Det er en array af transforms der repræsentere de waypoint som "enemiesne" ville bevæge sig på
    public Transform[] waypoints;
    // Farten som "enemiesne" bevæger sig mod waypointene
    public float moveSpeed = 5f;
    // index af det waypoint "enemien" bevæger sig mod
    private int waypointIndex = 0;
    void Update()
    {
        // hvis der stadig er waypoints at komme hentil
        if (waypointIndex < waypoints.Length)
        {
            // bevæge "enemien" mod det nuværende waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

            // hvis "enemien" er nået til nuværende waypoint så skift til næste waypoint
            if (transform.position == waypoints[waypointIndex].position)
            {
                waypointIndex++;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (waypoints != null || waypoints.Length > 1)
        {
            for (int i = 0; i < waypoints.Length - 1; i++)
            {
                if (waypoints[i] != null && waypoints[i + 1] != null)
                {
                    Debug.DrawLine(waypoints[i].position, waypoints[i + 1].position, Color.red);
                }
            }
        }
    }
}