using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPathfinding : MonoBehaviour
{
    public Transform[] waypoints; // an array of transforms representing the waypoints
    public Vector3[] segmentPoints; // an array of vector3 representing the control points for Bezier curves
    public int order = 2; // the order of the Bezier curves
    public int startIndex = 0; // index of the starting waypoint
    public float currentT; // the current t value for evaluating the Bezier curves
    public float speed = 1f; // how fast the object moves along the Bezier curves

    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
        startIndex = 0;
        currentT = 0f;
        segmentPoints = null;
    }

    public void Update()
    {
        currentT += Time.deltaTime * speed; // increase the current t value based on time and speed
        transform.position = EvaluatePosition(); // update the object's position based on the evaluated position
    }

    public Vector3 EvaluatePosition()
    {
        if (segmentPoints == null || !(segmentPoints.Length > 0))
        {
            FindNewSegmentPoints(); // if there are no segment points, find new ones based on the current index
        }
        else if (currentT >= 1f)
        {
            int temp = ((int)currentT - 1) + 1;
            startIndex += temp * order; // increase the start index based on the current t value and the order
            currentT %= 1f; // reset the current t value
            FindNewSegmentPoints(); // find new segment points based on the updated start index
        }
        Vector3 result = Bezier(segmentPoints, currentT); // evaluate the position using the Bezier curve

        return result;
    }

    private void FindNewSegmentPoints()
    {
        segmentPoints = new Vector3[order + 1]; // create an array of vector3 to store the segment points
        for (int i = 0; i < order + 1; i++)
        {
            segmentPoints[i] = waypoints[i + startIndex].position; // assign the positions of the waypoints to the segment points
        }
    }

    public Vector3 Bezier(Vector3[] positions, float t)
    {
        if (positions.Length < 2)
        {
            return positions[0]; // if there are not enough positions, return the first position
        }
        Vector3[] partial = new Vector3[positions.Length - 1];
        for (int i = 0; i < partial.Length; i++)
        {
            partial[i] = Vector3.Lerp(positions[i], positions[i + 1], t); // interpolate between positions to get partial positions
        }
        return Bezier(partial, t); // recursively call the Bezier function with the partial positions
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