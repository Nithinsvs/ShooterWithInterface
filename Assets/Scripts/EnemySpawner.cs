using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    public abstract IHealth CreateEnemy();

    public void SpawnEnemy(int localHealth)
    {
        IHealth functionality = CreateEnemy();
        functionality.health = localHealth;
        Debug.Log($"enemy with health{functionality.health} has been spawned");
    }
}
