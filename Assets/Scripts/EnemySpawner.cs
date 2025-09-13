using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    public abstract ISharedFunctionality CreateEnemy();

    public void SpawnEnemy(int localHealth)
    {
        ISharedFunctionality functionality = CreateEnemy();
        functionality.health = localHealth;
        Debug.Log($"enemy with health{functionality.health} has been spawned");
    }
}
