using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPathfinding : MonoBehaviour
{
    public Transform[] waypoints;
    public Vector3[] segmentPoints;
    public int order = 2;
    public int startIndex = 0;
    public float currentT;
    public float speed = 1f;

    public void Update()
    {
        currentT += Time.deltaTime * speed;
        transform.position = EvaluatePosition();
    }


    public Vector3 EvaluatePosition()
    {
        if (segmentPoints == null || !(segmentPoints.Length > 0))
        {
            FindNewSegmentPoints();
        }
        else if (currentT >= 1f)
        {
            int temp = ((int)currentT - 1)+1;
            startIndex += temp * order;
        currentT %= 1f;
            FindNewSegmentPoints();
        }
        Vector3 result = Bezier(segmentPoints,currentT);

        return result;
    }

    private void FindNewSegmentPoints()
    {
        segmentPoints = new Vector3[order + 1];
        for (int i = 0; i < order+1; i++)
        {
            segmentPoints[i] = waypoints[i + startIndex].position;
        }
    }

    public Vector3 Bezier(Vector3[] positions, float t)
    {
        if (positions.Length < 2)
        {
            return positions[0];
        }
        Vector3[] partial = new Vector3[positions.Length - 1];
        for (int i = 0; i < partial.Length; i++)
        {
            partial[i] = Vector3.Lerp(positions[i], positions[i + 1], t);
        }
        return Bezier(partial, t);
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

