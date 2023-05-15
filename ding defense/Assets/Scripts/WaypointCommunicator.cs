using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointCommunicator : MonoBehaviour
{
    public Transform[] waypoints; // an array of waypoints to follow

    // Define an event for sending waypoints
    public delegate void WaypointsEventHandler(Transform[] waypoints);
    public static event WaypointsEventHandler OnWaypointsUpdated;

    void Start()
    {
        UpdateWaypoints();
    }

    void OnEnable()
    {
        // Subscribe to the event for future enemy spawns
        StartCoroutine(CheckForEnemySpawn());
    }

    void OnDisable()
    {
        // Unsubscribe from the event
        StopCoroutine(CheckForEnemySpawn());
    }

    void UpdateWaypoints()
    {
        // Find all existing Enemy objects in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Update each Enemy with the waypoints
        foreach (GameObject enemy in enemies)
        {
            WaypointReceiver waypointReceiver = enemy.GetComponent<WaypointReceiver>();

            if (waypointReceiver != null)
            {
                waypointReceiver.ReceiveWaypoints(waypoints);
            }
            else
            {
                Debug.LogError("WaypointReceiver component not found on an Enemy GameObject.");
            }
        }
    }

    IEnumerator CheckForEnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            // Find newly spawned enemies with Enemy tag
            GameObject[] newEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Check if any new enemies have spawned
            if (newEnemies.Length > 0)
            {
                UpdateWaypoints();
            }
        }
    }
}
