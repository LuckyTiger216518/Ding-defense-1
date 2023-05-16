using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 1;

    public TextMeshProUGUI waveCounterText; // Reference to a TextMeshProUGUI component to display the wave count

    void Start()
    {
        waveCounterText.text = "Wave: 0"; // Initialize the wave counter text
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            waveCounterText.text = "Wave: " + waveIndex; // Update the wave counter text
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        

        for (int i = 0; i <= waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
        waveIndex++;
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
