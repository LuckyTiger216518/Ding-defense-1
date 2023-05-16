using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedBullet2 : MonoBehaviour
{
    private Transform target;
    Enemy enemyScript;
    int damage = 1;
    public float speed = 10f;
    public float curveStrength = 1f;
    private Vector3 initialDirection;
    private float distanceToTarget;

    public void Seek(Transform _target)
    {
        target = _target;
   ;
    }

    void Update()
    {
        if (target == null)
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
