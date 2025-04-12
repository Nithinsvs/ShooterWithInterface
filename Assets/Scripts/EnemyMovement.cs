using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    
   
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
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
            EnemyManager.enemyDead?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
