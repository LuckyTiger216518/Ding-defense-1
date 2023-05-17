using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointCommunicator : MonoBehaviour
{
    public Transform[] waypoints; // et array af waypoints, der skal følges

    // Definer en begivenhed til at sende waypoints
    public delegate void WaypointsEventHandler(Transform[] waypoints);
    public static event WaypointsEventHandler OnWaypointsUpdated;

    void Start()
    {
        UpdateWaypoints(); // Opdater waypoints ved start
    }

    void OnEnable()
    {
        // Abonner på begivenheden for fremtidige fjendespawn
        StartCoroutine(CheckForEnemySpawn());
    }

    void OnDisable()
    {
        // Afmeld begivenheden
        StopCoroutine(CheckForEnemySpawn());
    }

    void UpdateWaypoints()
    {
        // Find alle eksisterende Enemy-objekter i scenen
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Opdater hver Enemy med waypoints
        foreach (GameObject enemy in enemies)
        {
            WaypointReceiver waypointReceiver = enemy.GetComponent<WaypointReceiver>();

            if (waypointReceiver != null)
            {
                waypointReceiver.ReceiveWaypoints(waypoints); // Send waypoints til Enemy
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

            // Find ny-spawnede fjender med tagget "Enemy"
            GameObject[] newEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Tjek om der er nye fjender, der er spawnet
            if (newEnemies.Length > 0)
            {
                UpdateWaypoints(); // Opdater waypoints
            }
        }
    }
    void UpdatesWaypoints()
    {
        // Find alle eksisterende Enemy-objekter i scenen
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("FlyingEnemy");

        // Opdater hver Enemy med waypoints
        foreach (GameObject enemy in enemies)
        {
            WaypointReceiver waypointReceiver = enemy.GetComponent<WaypointReceiver>();

            if (waypointReceiver != null)
            {
                waypointReceiver.ReceiveWaypoints(waypoints); // Send waypoints til Enemy
            }
            else
            {
                Debug.LogError("WaypointReceiver component not found on an Enemy GameObject.");
            }
        }
    }
    IEnumerator ChecksForEnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            // Find ny-spawnede fjender med tagget "Enemy"
            GameObject[] newEnemies = GameObject.FindGameObjectsWithTag("FlyingEnemy");

            // Tjek om der er nye fjender, der er spawnet
            if (newEnemies.Length > 0)
            {
                UpdatesWaypoints(); // Opdater waypoints
            }
        }
    }
}
