using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointReceiver : MonoBehaviour
{
    private Transform[] waypoints; // an array of waypoints to follow
    private int currentWaypointIndex = 0; // the index of the current waypoint
    private float speed = 5f; // the speed at which to move the gameobject

    // receive the waypoints from the WaypointCommunicator script
    public void ReceiveWaypoints(Transform[] waypoints)
    {
        this.waypoints = waypoints;
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        // move towards the current waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // check if the gameobject has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // move to the next waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                // reached the last waypoint, reset to the first waypoint
                Destroy(gameObject);
            }
        }
    }
}