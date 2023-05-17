using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSetter : MonoBehaviour
{
    public Transform[] waypoints; // an array of waypoints to set

    void Start()
    {
        FlyingPathfinding flyingPathfinding = GetComponent<FlyingPathfinding>();
        if (flyingPathfinding != null)
        {
            flyingPathfinding.SetWaypoints(waypoints);
        }
        else
        {
            Debug.LogError("FlyingPathfinding component not found.");
        }
    }
}