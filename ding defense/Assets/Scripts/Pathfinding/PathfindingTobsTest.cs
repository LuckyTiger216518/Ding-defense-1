using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PathfindingTobsTest : MonoBehaviour
{
    private Transform[] waypoints; // array of waypoints som bliver fulgt
    public float moveSpeed = 5f; // farten den bevæger sig mod waypoints
    private int waypointIndex = 0; // et index af det nuværende waypoint

    void Start()
    {
        WaypointCommunicator.OnWaypointsUpdated += SetWaypoints; // subscribe til eventen der opdatere waypoints
    }

    private void OnDestroy()
    {
        WaypointCommunicator.OnWaypointsUpdated -= SetWaypoints;// her "unsubscriber den til det event når objectet er destroyed
    }
    // her sætter den array af waypoints og reseter waypoint indexet
    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
        waypointIndex = 0; // Her reseter waypoint index når den modtager nye waypoints

        // Sætter den start positionen for det første waypoint
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

        // Bevæger sig mod det nuværende waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

        // Så Checker den hvis "enemy" har noget det nuværende waypoint
        if (transform.position == waypoints[waypointIndex].position)
        {
            waypointIndex++;

            // Her destroyer den "enemy" gameobject når den når det sidste waypoint
            if (waypointIndex >= waypoints.Length)
            {
                GameObject enemyObject = gameObject.transform.Find("Enemy").gameObject;
                if (enemyObject != null)
                {
                    Destroy(enemyObject); // her bliver gameobjectet destroyet
                }
                else
                {
                    Debug.LogError("No enemy object found."); // her siger den hvis der ikke er noget enemy object fundet så logger den en error
                }
                return; // Her stopper den Update metoden for at stoppe flere updates
            }
        }
    }
}