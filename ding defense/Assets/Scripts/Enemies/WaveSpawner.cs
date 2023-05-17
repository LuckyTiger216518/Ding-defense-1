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

    // Vi laver 2 floats der skal bruges til at lave en nedt�lling til n�ste runde af fjender
    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    // vi laver en int der skal holde styr p� hvor mange runder der har v�ret
    private int waveIndex = 0;

    // vi laver et array der skal holde alle enemies p� banen
    GameObject[] enemiesInPlay;

    // vi laver et integer der skal fort�lle hvor mange fjender der er p� banen
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
        // if statementet siger at hvis vores "countdown" kommer ned p� 0 eller under skal der startes vores Coroutine "SpawnWave"
        if (countdown <= 0f && enemyCount == 0)
        {
            StartCoroutine(SpawnWave());
            waveCounterText.text = "Wave: " + waveIndex; // Update the wave counter text
            countdown = timeBetweenWaves;
        }

        // en t�ller, der t�ller nedad
        countdown -= Time.deltaTime;

        // den gemmer alle fjender inde i vores "enemiesInPlay" array
        enemiesInPlay = GameObject.FindGameObjectsWithTag("Enemy");

        // den finder ud af hvor mange fjender der er p� banen, ved at kigge p� hvor mange fjender der er i "enemiesInPlay" arrayet
        enemyCount = enemiesInPlay.Length;
    }

    // Vi bruger IEnumerator til at lave en coroutine med en pause i sig. coroutinen g�r ind og instantiater liges� mange fjender som der har v�ret runder.
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
