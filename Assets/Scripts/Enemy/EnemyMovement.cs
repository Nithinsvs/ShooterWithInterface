using Nithin.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Enemy
{
    public class EnemyMovement : MonoBehaviour, IScoreProvider, IEnemy
    {
        public event Action<EnemyMovement, DeathReason> OnEnemyDied;

        [SerializeField] private float speed = 10f;
        [SerializeField] private int score = 2;
        [SerializeField] private int autoDestroyTime = 5;

        private Rigidbody2D rb;
        private WaitForSeconds waitTimeToKill;
        public int ScoreValue => score;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            StartCoroutine(KillEnemy());
        }

        public void Initialize()
        {
            transform.position = new Vector3(0, 5, 0);
            waitTimeToKill = new WaitForSeconds(autoDestroyTime);
        }

        IEnumerator KillEnemy()
        {
            yield return waitTimeToKill;
            OnEnemyDied?.Invoke(this, DeathReason.TimeOut);
            EnemyDeath();
        }

        private void EnemyDeath()
        {
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + Vector2.down * Time.fixedDeltaTime * speed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.SetActive(false);
            }
            else if (collision.gameObject.CompareTag("Bullet"))
            {
                collision.gameObject.SetActive(false);
                OnEnemyDied?.Invoke(this, DeathReason.Player);
                EnemyDeath();
            }
        }

    }
}