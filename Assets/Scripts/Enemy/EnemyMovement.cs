using Nithin.Core;
using System;
using System.Collections;
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
        private WaitForSeconds _killWait;
        private Vector2 _moveStep;

        public int ScoreValue => score;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            _killWait = new WaitForSeconds(autoDestroyTime);
            _moveStep = Vector2.down * speed;
        }

        private void OnEnable()
        {
            StartCoroutine(KillEnemy());
        }

        public void Initialize(Vector2 initialPosition)
        {
            if (rb != null)
            {
                rb.position = initialPosition;
            }
            else
            {
                transform.position = initialPosition;
            }
        }

        private IEnumerator KillEnemy()
        {
            yield return _killWait;
            OnEnemyDied?.Invoke(this, DeathReason.TimeOut);
            EnemyDeath();
        }

        private void EnemyDeath()
        {
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (rb == null)
            {
                return;
            }

            rb.MovePosition(rb.position + _moveStep * Time.fixedDeltaTime);
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
