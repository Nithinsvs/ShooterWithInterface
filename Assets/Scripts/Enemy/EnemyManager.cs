using Nithin.Core;
using Nithin.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Nithin.Enemy
{
    public class EnemyManager : MonoBehaviour
    {        
        private IScoreReceiver scoreReceiver;
        [SerializeField] private MonoBehaviour scoreAdderComponent;
        [SerializeField] private List<GameObject> enemyPrefab = new();        

        private Queue<GameObject> enemyObjects;
        private List<EnemyMovement> gameObjects = new();

        void Awake()
        {
            scoreReceiver = scoreAdderComponent as IScoreReceiver;
        }

        // Start is called before the first frame update
        void Start()
        {
            enemyObjects = new Queue<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                GameObject enemyObj = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Count)], new Vector3(Random.Range(-5, 5), 5f), Quaternion.identity);
                enemyObj.SetActive(false);
                enemyObjects.Enqueue(enemyObj);
            }
            StartCoroutine(SpawnEnemy());
        }

        IEnumerator SpawnEnemy()
        {
            while (true)
            {
                GameObject spawnedObj = enemyObjects.Dequeue();
                IEnemy enemy = spawnedObj.GetComponent<IEnemy>();
                enemy.Initialize();
                spawnedObj.SetActive(true);

                EnemyMovement enemyMovement = spawnedObj.GetComponent<EnemyMovement>();
                Register(enemyMovement);
                yield return new WaitForSeconds(3f);
            }
        }

        private void Register(EnemyMovement go)
        {
            gameObjects.Add(go);
            go.OnEnemyDied += HandleDeath;
        }

        private void HandleDeath(EnemyMovement go, DeathReason deathReason)
        {
            if (deathReason == DeathReason.Player)
            {
                scoreReceiver.AddScore(go.ScoreValue);
            }
            go.OnEnemyDied -= HandleDeath;
            enemyObjects.Enqueue(go.gameObject);
        }
    }
}