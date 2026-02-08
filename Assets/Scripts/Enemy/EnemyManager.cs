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
                EnemyMovement enemyMovement = spawnedObj.GetComponent<EnemyMovement>();
                spawnedObj.SetActive(true);
                Register(enemyMovement);
                StartCoroutine(DisableEnemy(spawnedObj, enemyMovement.autoDestroyTime));
                yield return new WaitForSeconds(3f);
            }
        }

        private void Register(EnemyMovement go)
        {
            gameObjects.Add(go);
            go.OnEnemyDied += HandleDeath;
        }

        IEnumerator DisableEnemy(GameObject obj, int autoDestroy)
        {
            yield return new WaitForSeconds(autoDestroy);
            obj.SetActive(false);
            obj.transform.position = new Vector3(0, 5, 0);
            enemyObjects.Enqueue(obj);
        }

        private void HandleDeath(EnemyMovement go)
        {
            scoreReceiver.AddScore(go.ScoreValue);
            go.OnEnemyDied -= HandleDeath;
        }
    }
}