using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Enemy
{
    public class EnemyMovement : MonoBehaviour, IScoreProvider
    {
        public event Action<IScoreProvider> OnEnemyDied;

        [SerializeField] private float speed = 10f;
        [SerializeField] private int score = 2;


        private Rigidbody2D rb;

        public int ScoreValue => score;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
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
                OnEnemyDied?.Invoke(this);
                gameObject.SetActive(false);
            }
        }
    }
}