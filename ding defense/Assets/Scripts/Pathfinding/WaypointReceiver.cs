using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointReceiver : MonoBehaviour
{
    private Transform[] waypoints; // et array af waypoints, der skal følges
    private int currentWaypointIndex = 0; // index for det aktuelle waypoint
    private float speed = 5f; // hastigheden, hvormed spilobjektet bevæger sig

    // modtag waypoints fra WaypointCommunicator-scriptet
    public void ReceiveWaypoints(Transform[] waypoints)
    {
        this.waypoints = waypoints; // opdater waypoints
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return; // hvis der ikke er waypoints, eller arrayet er tomt, afslut metoden
        }

        // bevæg mod det aktuelle waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // tjek om spilobjektet har nået det aktuelle waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // gå til næste waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                Destroy(gameObject); // ødelæg spilobjektet
            }
        }
    }
}