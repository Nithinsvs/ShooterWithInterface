using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerManager : MonoBehaviour, IScore
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletsHolder;
        [SerializeField] private Queue<GameObject> bulletsPool;
        [SerializeField] private Rigidbody2D rb;

        private int score = 0;
        Vector2 movement;

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
            
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                GameObject currentBullet = bulletsPool.Dequeue();
                currentBullet.transform.position = transform.position;
                currentBullet.SetActive(true);
                StartCoroutine(ReturnToPool(currentBullet));

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

        public void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
        }
    }
}