using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    // vi henter positionen af vores enemyPrefab
    public Transform enemyPrefab;

    // vi henter positionen af vores enemyPrefab
    public Transform flyingEnemyPrefab;

    //vi henter positionen af vores object der hedder "spawnPoint"
    public Transform spawnPoint;

    // Vi laver 2 floats der skal bruges til at lave en nedtælling til næste runde af fjender
    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    // vi laver en int der skal holde styr på hvor mange runder der har været
    private int waveIndex = 0;

    // vi laver et array der skal holde alle enemies på banen
    GameObject[] enemiesInPlay;

    // vi laver et integer der skal fortælle hvor mange fjender der er på banen
    public int enemyCount;

    private int flyingEnemySpawnCount;
  

    public TextMeshProUGUI waveCounterText; // Reference to a TextMeshProUGUI component to display the wave count

    void Start()
    {
        waveCounterText.text = "Wave: 0"; // Initialize the wave counter text
        flyingEnemySpawnCount = 5;
    }

    void Update()
    {
        // if statementet siger at hvis vores "countdown" kommer ned på 0 eller under skal der startes vores Coroutine "SpawnWave"
        if (countdown <= 0f && enemyCount == 0)
        {
            StartCoroutine(SpawnWave());
            waveCounterText.text = "Wave: " + waveIndex; // Update the wave counter text
            countdown = timeBetweenWaves;
        }

        // en tæller, der tæller nedad
        countdown -= Time.deltaTime;

        // den gemmer alle fjender inde i vores "enemiesInPlay" array
        enemiesInPlay = GameObject.FindGameObjectsWithTag("Enemy");

        // den finder ud af hvor mange fjender der er på banen, ved at kigge på hvor mange fjender der er i "enemiesInPlay" arrayet
        enemyCount = enemiesInPlay.Length;
    }

    // Vi bruger IEnumerator til at lave en coroutine med en pause i sig. coroutinen går ind og instantiater ligeså mange fjender som der har været runder.
    IEnumerator SpawnWave()
    {
        for (int i = 0; i <= waveIndex; i++)
        {
            if (waveIndex == flyingEnemySpawnCount)
            {
                SpawnFlyingEnemy();
                flyingEnemySpawnCount += 5;
            }
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        waveIndex++;
    }

    // spawnEnemy instantiater en fjende.
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    //
    void SpawnFlyingEnemy()
    {
        Instantiate(flyingEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
