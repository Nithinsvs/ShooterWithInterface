using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Core
{
    public class FactoryEnemyCreator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemyPrefabs;
        
        public GameObject CreateRandomEnemy(Vector3 enemyPosition)
        {
            int randomIndex = Random.Range(0, _enemyPrefabs.Count);
            GameObject enemyToSpawn = Instantiate(_enemyPrefabs[randomIndex], enemyPosition, Quaternion.identity);

            return enemyToSpawn;
        }
        
    }
}