using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedBullet : MonoBehaviour
{
    //s�tter hastighed p� projektil (adgang i editor)
    public float speed = 10f;

    //kurven styrke p� projektil (adgang i editor)
    public float curveStrength = 1f;

    //finder target fra tower script
    private Transform target;

    //s�tter skade p� enemies
    int damage = 1;

    //laver vektor til target
    private Vector3 initialDirection;

    //beregner l�ngden til target
    private float distanceToTarget;

    //leder efter objekttags med target
    public void Seek(Transform _target)
    {
        target = _target;

        //kalder p� koden 
        CalculateInitialDirection();
    }


    private void CalculateInitialDirection()
    {

        //udregner l�ngden fra target hver gang target er i range for toweret
        if (target != null)
        {
            //med vektorere tager den position fra tower/projektil til target position
            initialDirection = (target.position - transform.position).normalized;
            distanceToTarget = Vector3.Distance(transform.position, target.position);
        }
    }


    private void Update()
    {
        //hvis target er i i range (target ikke er ikke i range)
        if (target != null)
        {

            //float laves ved brug af lerp til at udregne kurve fra target position og tower position ved hj�lp af vektor distance.
            float curveOffset = Mathf.Lerp(0f, curveStrength, 1f - (Vector3.Distance(transform.position, target.position) / distanceToTarget));

            //udregn med den nye float ind s�dan at der bliver lavet en pr�cis kurv i retningen mod target 
            Vector3 curvedDirection = Quaternion.Euler(0f, curveOffset, 0f) * initialDirection;
 
            //skyd projektilet i den kurv som er beregnet i koden over med hastighed og styrke fra oven
            transform.Translate(curvedDirection * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target != null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }


    void HitTarget()
    {
        target.GetComponent<Enemy>().TakeDamage(1);
    }
}
