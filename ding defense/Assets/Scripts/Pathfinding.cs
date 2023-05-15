using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pathfinding : MonoBehaviour
{
    private Transform[] waypoints; // an array of waypoints to follow
    public float moveSpeed = 5f; // the speed at which to move towards the waypoints
    private int waypointIndex = 0; // index of the current waypoint

    void Start()
    {
        WaypointCommunicator.OnWaypointsUpdated += SetWaypoints;
    }

    private void OnDestroy()
    {
        WaypointCommunicator.OnWaypointsUpdated -= SetWaypoints;
    }

    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
        waypointIndex = 0; // Reset the waypoint index when receiving new waypoints

        // Set the initial position to the first waypoint
        if (waypoints != null && waypoints.Length > 0)
        {
            transform.position = waypoints[waypointIndex].position;
        }
    }
    void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints assigned to the Pathfinding script.");
            return;
        }

        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the current waypoint
        if (transform.position == waypoints[waypointIndex].position)
        {
            waypointIndex++;

            // If reached the last waypoint, destroy the enemy game object
            if (waypointIndex >= waypoints.Length)
            {
                GameObject enemyObject = gameObject.transform.Find("Enemy").gameObject;
                if (enemyObject != null)
                {
                    Destroy(enemyObject);
                }
                else
                {
                    Debug.LogError("No enemy object found.");
                }
                return; // Exit the Update method to prevent further updates
            }
        }
    }
}