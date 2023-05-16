using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform target;

    [Header("PossibleUpgrades")]
    //Giver et omr�de, som t�rnet kan se i
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
        /*F�r vores "UpdateTarget" til kun at update et par gange i 
         sekundetet frem for 60-120 gange, for bl.a. at spare computeren
         for lidt arbejde*/
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //Kigger efter n�rmeste enemy inden for r�kkevidde
    void UpdateTarget()
    {
        //Array for alle vores enemies med tagget "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //Gemmer korteste afstand til enemy
        /*Bruger mathf.infinity i forhold til hvis der ikke er et enemy
         i n�rheden, s� kan der v�re uendeligt langt over til n�rmeste enemy*/
        float shortestDistance = Mathf.Infinity;

        //Gemmer det enemy som er t�ttest p�
        GameObject nearestEnemy = null;

        //Kigger alle enemies "in our seem" igennem
        foreach (GameObject enemy in enemies)
        {
            //Tjekker afstanden mellem t�rnet og enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            /*Hvis distanceToEnemy er mindre end shortestDistance, s� har vi
             fundet en ny shortest distance, og har derfor ogs� fundet et enemy,
            som er t�ttere p� end den forrige*/
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        /*Hvis der er et enemy, hvis det er det t�tteste enemy, og hvis det er 
         * inden for vores r�kkevidde, s� bliver enemiet til vores target,
         eller g�r den ikke noget*/
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
         ikke har det, s� g�r den ikke noget*/
        if (target == null)
        {
            return;
        }

        //En vektor som peger p� vores enemy
        Vector3 direction = target.position - transform.position;

        //Hvordan skal t�rnet rotere, s� det peger samme vej som vores vektor?
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        //Omdanner vores quaternion til reelt, at f� vores t�rne til at dreje om x,y,z-akserne
        Vector3 rotation = lookRotation.eulerAngles;

        //F�r vores t�rn til kun at dreje om y-aksen
        rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        /*Hvis der ikke er en countdown p� vores skud, s� skyder vi, og derefter
         bliver countdownen resat*/
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        //F�r vores countdown til rent faktisk at t�lle ned
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
        //Giver os mulighed for at se t�rnets omr�de
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
