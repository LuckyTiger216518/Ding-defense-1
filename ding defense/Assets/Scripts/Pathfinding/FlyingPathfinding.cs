using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPathfinding : MonoBehaviour
{
    public Transform[] waypoints; // et array af transforms som repr�senterer waypointsne
    public Vector3[] segmentPoints; // et array af vector3 som repr�senterer "control points" for Bezier kurverne
    public int order = 2; // orderen af Bezier kurverne
    public int startIndex = 0; // index af starting waypointet
    public float currentT; // den nuv�rende t v�rdi for at evalurere Bezier kurverne
    public float speed = 1f; // hvor hurtigt objectet bev�ger sig langs Bezier kurverne
 
    public void Update()
    {
        currentT += Time.deltaTime * speed; // �g den aktuelle t-v�rdi baseret p� tid og hastighed
        transform.position = EvaluatePosition(); // opdater objektets position baseret p� den evaluerede position
    }


    public Vector3 EvaluatePosition()
    {
        if (segmentPoints == null || !(segmentPoints.Length > 0))
        {
            FindNewSegmentPoints(); // hvis der ikke er segmentpunkter, find nye baseret p� det aktuelle indeks
        }
        else if (currentT >= 1f)
        {
            int temp = ((int)currentT - 1)+1;
            startIndex += temp * order; // �g startindekset baseret p� den aktuelle t-v�rdi og ordren
            currentT %= 1f; // nulstil den aktuelle t-v�rdi
            FindNewSegmentPoints(); // find nye segmentpunkter baseret p� det opdaterede startindeks
        }
        Vector3 result = Bezier(segmentPoints,currentT); // evalu�r positionen ved hj�lp af Bezier-kurven

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
            return positions[0]; // hvis der ikke er nok positioner, returner den f�rste position
        }
        Vector3[] partial = new Vector3[positions.Length - 1];
        for (int i = 0; i < partial.Length; i++)
        {
            partial[i] = Vector3.Lerp(positions[i], positions[i + 1], t); // interpol�r mellem positioner for at f� delvise positioner
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

