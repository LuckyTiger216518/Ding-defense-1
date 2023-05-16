using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform target;

    [Header("PossibleUpgrades")]
    //Giver et område, som tårnet kan se i
    public float range = 10f;

    //Hvor hurtigt der bliver skudt
    public float fireRate = 1f;

    //En countdown for hvor hurtigt vi kan skyde
    private float fireCountdown = 0f;

    [Header("Requirements")]
    //Laver et tag til enemies
    public string enemyTag = "Enemy";

    //Make it turn
    public Transform rotate;

    //idk man.. bullets
    public GameObject bulletPrefab;

    //Hvor bullet bliver skudt fra
    public Transform firePoint;

    private float towerHeight;


    void Start()
    {
        /*Får vores "UpdateTarget" til kun at update et par gange i 
         sekundetet frem for 60-120 gange, for bl.a. at spare computeren
         for lidt arbejde*/
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //Kigger efter nærmeste enemy inden for rækkevidde
    void UpdateTarget()
    {
        //Array for alle vores enemies med tagget "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //Gemmer korteste afstand til enemy
        /*Bruger mathf.infinity i forhold til hvis der ikke er et enemy
         i nærheden, så kan der være uendeligt langt over til nærmeste enemy*/
        float shortestDistance = Mathf.Infinity;

        //Gemmer det enemy som er tættest på
        GameObject nearestEnemy = null;

        //Kigger alle enemies "in our seem" igennem
        foreach (GameObject enemy in enemies)
        {
            //Tjekker afstanden mellem tårnet og enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            /*Hvis distanceToEnemy er mindre end shortestDistance, så har vi
             fundet en ny shortest distance, og har derfor også fundet et enemy,
            som er tættere på end den forrige*/
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        /*Hvis der er et enemy, hvis det er det tætteste enemy, og hvis det er 
         * inden for vores rækkevidde, så bliver enemiet til vores target,
         eller gør den ikke noget*/
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }

        else
        {
            target = null;
        }

    }
    private bool IsEnemyAtSameHeight(GameObject enemy)
    {
        return Mathf.Approximately(enemy.transform.position.y, towerHeight);
    }


    void Update()
    {
        /*Tjekker om vi overhovedet har et target, hvis vi
         ikke har det, så gør den ikke noget*/
        if (target == null)
        {
            return;
        }

        //En vektor som peger på vores enemy
        Vector3 direction = target.position - transform.position;

        //Hvordan skal tårnet rotere, så det peger samme vej som vores vektor?
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        //Omdanner vores quaternion til reelt, at få vores tårne til at dreje om x,y,z-akserne
        Vector3 rotation = lookRotation.eulerAngles;

        //Får vores tårn til kun at dreje om y-aksen
        rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        /*Hvis der ikke er en countdown på vores skud, så skyder vi, og derefter
         bliver countdownen resat*/
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        //Får vores countdown til rent faktisk at tælle ned
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        
        //Spawner vores bullet
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
       
        }

        CurvedBullet bullet2 = bulletGO.GetComponent<CurvedBullet>();

        if (bullet2 != null)
        {
            bullet2.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Giver os mulighed for at se tårnets område
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
