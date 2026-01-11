using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public Action<EnemyMovement> OnEnemyDied;

        [SerializeField] private float speed = 10f;

        private Rigidbody2D rb;

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