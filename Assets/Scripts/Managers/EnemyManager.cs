using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Vector3 spawnCenter;
    public Vector3 spawnArea;

    public List<Transform> targetPositions;

    public void SpawnEnemy()
    {
        Vector3 center = spawnCenter + transform.position;
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Count);
        Vector3 randomPosition = new Vector3(Random.Range(center.x - spawnArea.x / 2, center.x + spawnArea.x / 2),
            Random.Range(center.y - spawnArea.y / 2, center.y + spawnArea.y / 2),
            Random.Range(center.z - spawnArea.z / 2, center.z + spawnArea.z / 2));
        GameObject enemy = Instantiate(enemyPrefabs[randomEnemyIndex], randomPosition, Quaternion.identity);
        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        enemy.transform.forward = -transform.right;

        // 距离最近的目标点
        Transform target = targetPositions[0];
        float minDistance = Vector3.Distance(target.position, enemy.transform.position);
        foreach (var targetPosition in targetPositions)
        {
            float distance = Vector3.Distance(targetPosition.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                target = targetPosition;
            }
        }
        enemyComponent.Target = target.position;
    }

    float timer = 0;
    float spawnRate = 2f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            timer = 0;
            SpawnEnemy();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnCenter + transform.position, spawnArea);
    }
}
