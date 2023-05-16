using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    Enemy enemyScript;
    int damage = 1;

    //Se video igen fra det her punkt (for træt til at forstå) (omkring 09:15)

    public float speed = 70f;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
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
