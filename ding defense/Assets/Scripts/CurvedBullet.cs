using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedBullet : MonoBehaviour
{
    public float speed = 10f;
    public float curveStrength = 1f;
    private Transform target;
    int damage = 1;

    private Vector3 initialDirection;
    private float distanceToTarget;


    public void Seek(Transform _target)
    {
        target = _target;
        CalculateInitialDirection();
    }


    private void CalculateInitialDirection()
    {
        if (target != null)
        {
            initialDirection = (target.position - transform.position).normalized;
            distanceToTarget = Vector3.Distance(transform.position, target.position);
        }
    }


    private void Update()
    {
        if (target != null)
        {
            Debug.Log(Vector3.Distance(transform.position, target.position) / distanceToTarget);

            float curveOffset = Mathf.Lerp(0f, curveStrength, 1f - (Vector3.Distance(transform.position, target.position) / distanceToTarget));

            Vector3 curvedDirection = Quaternion.Euler(0f, curveOffset, 0f) * initialDirection;
 
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
