using Nithin.Core;
using Nithin.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        private const float SpawnXMin = -5f;
        private const float SpawnXMax = 5f;
        private const float SpawnY = 5f;

        private IScoreReceiver scoreReceiver;
        [SerializeField] private MonoBehaviour scoreAdderComponent;

        [SerializeField] private FactoryEnemyCreator _enemyFactory;
        [SerializeField] private int _poolPreloadCount = 10;
        [SerializeField] private float _spawnIntervalSeconds = 3f;

        private readonly Queue<GameObject> _enemyPoolObjects = new();
        private WaitForSeconds _spawnWait;

        private void Awake()
        {
            scoreReceiver = scoreAdderComponent as IScoreReceiver;
            _spawnWait = new WaitForSeconds(_spawnIntervalSeconds);
        }

        private void Start()
        {
            for (int i = 0; i < _poolPreloadCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(SpawnXMin, SpawnXMax), SpawnY);
                GameObject enemyObject = _enemyFactory.CreateRandomEnemy(spawnPosition);
                if (enemyObject == null)
                {
                    continue;
                }

                enemyObject.SetActive(false);
                _enemyPoolObjects.Enqueue(enemyObject);
            }

            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                while (_enemyPoolObjects.Count == 0)
                {
                    yield return null;
                }

                GameObject spawnedObj = _enemyPoolObjects.Dequeue();
                Vector2 spawnPosition = new Vector2(Random.Range(SpawnXMin, SpawnXMax), SpawnY);

                if (spawnedObj.TryGetComponent(out EnemyMovement enemyMovement))
                {
                    enemyMovement.Initialize(spawnPosition);
                    enemyMovement.OnEnemyDied += HandleDeath;
                }

                spawnedObj.SetActive(true);
                yield return _spawnWait;
            }
        }

        private void HandleDeath(EnemyMovement go, DeathReason deathReason)
        {
            if (deathReason == DeathReason.Player)
            {
                scoreReceiver.AddScore(go.ScoreValue);
            }

            go.OnEnemyDied -= HandleDeath;
            _enemyPoolObjects.Enqueue(go.gameObject);
        }
    }
}
