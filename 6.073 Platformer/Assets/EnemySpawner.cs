using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Platformer target;
    public GameObject enemyPrefab;
    public int seed;
    public double enemySpawnTime;
    public double enemyRampup;
    public float enemySpawnDistance;

    private System.Random rng;

    private double enemySpawnCooldown = 0.0;
    private int enemiesSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        rng = new System.Random(seed);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawnCooldown <= 0)
        {
            SpawnEnemy();
            enemiesSpawned += 1;
            enemySpawnCooldown = enemySpawnTime / (1 + enemyRampup * enemiesSpawned);
        }
        else
        {
            enemySpawnCooldown -= Time.deltaTime;
        }
    }
    void SpawnEnemy()
    {
        Vector2 dir = new Vector2(2 * (float)rng.NextDouble() - 1, (float)rng.NextDouble());
        dir = dir / dir.magnitude;
        Enemy enemy = Instantiate(enemyPrefab, target.transform.position + (Vector3)dir * enemySpawnDistance, new Quaternion(0, 0, 0, 1))
            .GetComponent<Enemy>();
        enemy.target = target;
    }
}
