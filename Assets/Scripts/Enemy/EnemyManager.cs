using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        public static Action enemyDead;

        [SerializeField] private GameObject enemyPrefab;        
        [SerializeField] private MonoBehaviour scoreAdderComponent;
        private IHealth healthComponent;
        [SerializeField] private MonoBehaviour healthComponentThing;

        private Queue<GameObject> enemyObjects;
        private IScore scoreAdder;
        private int healthToAdd = 1;
        private int enemyScore;

        void Awake()
        {
            scoreAdder = scoreAdderComponent as IScore;
            healthComponent = healthComponentThing as IHealth;
        }

        private void OnEnable()
        {
            enemyDead += DeadCondition;
        }

        private void OnDisable()
        {
            enemyDead -= DeadCondition;
        }

        // Start is called before the first frame update
        void Start()
        {
            enemyObjects = new Queue<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                GameObject enemyObj = Instantiate(enemyPrefab, new Vector3(Random.Range(-5, 5), 5f), Quaternion.identity);
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
                spawnedObj.SetActive(true);
                StartCoroutine(DisableEnemy(spawnedObj));
                yield return new WaitForSeconds(3f);
            }
        }

        IEnumerator DisableEnemy(GameObject obj)
        {
            yield return new WaitForSeconds(5f);
            obj.SetActive(false);
            obj.transform.position = new Vector3(0, 5, 0);
            enemyObjects.Enqueue(obj);
        }

        private void DeadCondition()
        {
            scoreAdder.AddScore(1);
            healthComponent.AddHealth(healthToAdd);
        }
    }
}