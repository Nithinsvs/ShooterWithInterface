using Nithin.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletsHolder;
        [SerializeField] private Queue<GameObject> bulletsPool;
        [SerializeField] private Rigidbody2D rb;
        

        private Vector2 movement;
        private PlayerState currentState = PlayerState.Normal;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        void Start()
        {
            bulletsPool = new Queue<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                GameObject spawnedObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bulletsPool.Enqueue(spawnedObj);
                spawnedObj.SetActive(false);
                spawnedObj.transform.SetParent(bulletsHolder);
            }
        }

        // Update is called once per frame
        void Update()
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            movement = new Vector2(moveHorizontal, moveVertical).normalized;

            switch (currentState)
            {
                case PlayerState.Normal:

                    ShootLogic();
                    break;

                case PlayerState.Shooting:

                    ShootLogic();
                    break;
            }
        }

        private void ShootLogic()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                GameObject currentBullet = bulletsPool.Dequeue();
                currentBullet.transform.position = transform.position;
                currentBullet.SetActive(true);
                StartCoroutine(ReturnToPool(currentBullet));

                ChangeState(PlayerState.Shooting);
            }
        }

        private void ChangeState(PlayerState newState)
        {
            if (currentState == newState)
            {
                return;
            }
            currentState = newState;
            switch (currentState)
            {
                case PlayerState.Normal:
                    Debug.Log("Player is in normal state");
                    break;
                case PlayerState.Shooting:
                    Debug.Log("Player is in shooting state");
                    break;
                case PlayerState.Dead:
                    Debug.Log("Player is in dead state");
                    break;
            }
        }

        void FixedUpdate()
        {
            Vector2 targetPosition = rb.position + movement * Time.fixedDeltaTime * speed;

            targetPosition.x = Mathf.Clamp(targetPosition.x, -5f, 5f);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -5f, 5f);
            rb.MovePosition(targetPosition);
        }

        IEnumerator ReturnToPool(GameObject bullet)
        {
            yield return new WaitForSeconds(3f);
            bullet.SetActive(false);
            bulletsPool.Enqueue(bullet);
        }
    }
}