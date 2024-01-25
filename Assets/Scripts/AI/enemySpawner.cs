// EnemySpawner.cs
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public int maxEnemies = 10;

    private int currentEnemies = 0;
    private bool isSpawning = true;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (isSpawning && currentEnemies < maxEnemies)
        {
            Instantiate(enemyPrefab, GetRandomSpawnPoint(), Quaternion.identity);
            currentEnemies++;
        }
    }

    Vector3 GetRandomSpawnPoint()
    {
        Vector3 spawnPoint = new Vector3(
            Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2),
            transform.position.y,
            Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2)
        );

        return spawnPoint;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject); // Destroy the bullet
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        // Handle spawner taking damage (e.g., decrease health, play effects)
        // Check if the spawner has been destroyed
        if (currentEnemies <= 0)
        {
            Destroy(gameObject);
        }
    }
}
