using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public float waveCoolDown = 10f;
    public float waveCountDown = 2f;
    public float enemySpawnGapInterval = 0.2f;
    public float enemyHealth = 5f;
    public float enemySpeed = 1f;

    public GameObject enemyPrefab;
    public Transform spawnPoint;

    public Text waveCountDownText;
    public Text WaveNumberText;

    private int waveNumber = 0;

    void Update() {
        if (waveCountDown <= 0f) {
            StartCoroutine(SpawnWave());

            waveCountDown = waveCoolDown;
        }

        waveCountDown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(waveCountDown).ToString();
        WaveNumberText.text = waveNumber.ToString();
    }

    IEnumerator SpawnWave() {
        waveNumber++;

        for (int i = 0; i < waveNumber; ++i) {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnGapInterval);
        }

        enemyHealth += 2f;
        enemySpeed += 0.2f;
        waveCoolDown += 5f;
    }

    void SpawnEnemy() {
        GameObject enemyGO = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);  // Instantiate GameObject
        Enemy enemy = enemyGO.GetComponent<Enemy>();

        enemy.health = enemyHealth;
        enemy.speed = enemySpeed;
    }
}
