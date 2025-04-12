using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IScore
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletsHolder;
    [SerializeField] private Queue<GameObject> bulletsPool;

    private int score = 0;

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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        transform.position += movement * Time.deltaTime * speed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5f, 5f),
                                        Mathf.Clamp(transform.position.y, -5f, 5f), 0f);

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject currentBullet = bulletsPool.Dequeue();
            currentBullet.transform.position = transform.position;
            currentBullet.SetActive(true);
            StartCoroutine(ReturnToPool(currentBullet));
            
        }
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
