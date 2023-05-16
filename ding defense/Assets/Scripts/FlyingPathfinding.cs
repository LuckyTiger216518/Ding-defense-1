using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPathfinding : MonoBehaviour
{
    public Transform[] waypoints; // et array af transforms som repræsenterer waypointsne
    public Vector3[] segmentPoints; // et array af vector3 som repræsenterer "control points" for Bezier kurverne
    public int order = 2; // orderen af Bezier kurverne
    public int startIndex = 0; // index af starting waypointet
    public float currentT; // den nuværende t værdi for at evalurere Bezier kurverne
    public float speed = 1f; // hvor hurtigt objectet bevæger sig langs Bezier kurverne
 
    public void Update()
    {
        currentT += Time.deltaTime * speed; // øg den aktuelle t-værdi baseret på tid og hastighed
        transform.position = EvaluatePosition(); // opdater objektets position baseret på den evaluerede position
    }


    public Vector3 EvaluatePosition()
    {
        if (segmentPoints == null || !(segmentPoints.Length > 0))
        {
            FindNewSegmentPoints(); // hvis der ikke er segmentpunkter, find nye baseret på det aktuelle indeks
        }
        else if (currentT >= 1f)
        {
            int temp = ((int)currentT - 1)+1;
            startIndex += temp * order; // øg startindekset baseret på den aktuelle t-værdi og ordren
            currentT %= 1f; // nulstil den aktuelle t-værdi
            FindNewSegmentPoints(); // find nye segmentpunkter baseret på det opdaterede startindeks
        }
        Vector3 result = Bezier(segmentPoints,currentT); // evaluér positionen ved hjælp af Bezier-kurven

        return result;
    }

    private void FindNewSegmentPoints()
    {
        segmentPoints = new Vector3[order + 1]; // opret et array af vector3 til at gemme segmentpunkterne
        for (int i = 0; i < order+1; i++)
        {
            segmentPoints[i] = waypoints[i + startIndex].position; // tildel waypointenes positioner til segmentpunkterne
        }
    }

    public Vector3 Bezier(Vector3[] positions, float t)
    {
        if (positions.Length < 2)
        {
            return positions[0]; // hvis der ikke er nok positioner, returner den første position
        }
        Vector3[] partial = new Vector3[positions.Length - 1];
        for (int i = 0; i < partial.Length; i++)
        {
            partial[i] = Vector3.Lerp(positions[i], positions[i + 1], t); // interpolér mellem positioner for at få delvise positioner
        }
        return Bezier(partial, t); // kald rekursivt Bezier-funktionen med de delvise positioner
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

