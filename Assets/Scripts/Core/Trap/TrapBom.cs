using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBom : MonoBehaviour
{
    [SerializeField] float height;
    [SerializeField] float width;
    [SerializeField] LayerMask playerLayer;
    BoxCollider2D boxCollider2D;
    [SerializeField] GameObject rocket;
    [SerializeField] float timeToSpawn;
    float timer;
    [SerializeField] float radiusSpawnRocket;
    [SerializeField] Transform rocketParent;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    bool isPlayerEnter;
    private void Start()
    {
        boxCollider2D.size = new Vector2(width, height);
    }
    private void Update()
    {
        if (isPlayerEnter && timer < 0)
        {
            SpawnBoom();
        }
        timer -= Time.deltaTime;
    }
    public void SpawnBoom()
    {
        Collider2D col = Physics2D.OverlapBox(transform.position , new Vector2(width , height), 0f, playerLayer);
        if (col != null)
        {
            PlayerController player = col.GetComponent<PlayerController>();
            if (player != null)
            {
                int rocketCount = UnityEngine.Random.Range(3, 5); 
                for (int i = 0; i < rocketCount; i++)
                {
                    Vector2 spawnPosition = (Vector2)player.transform.position + Random.insideUnitCircle * radiusSpawnRocket;
                    GameObject newRocket = MyPoolManager.Instance.GetFromPool(rocket, rocketParent);
                    newRocket.transform.position = new Vector3(spawnPosition.x, Camera.main.transform.position.y + Camera.main.orthographicSize + 1, 0);
                    newRocket.GetComponent<Rocket>().Move(spawnPosition);
                }
                timer = timeToSpawn;

            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position , new Vector3(width, height, 0));
        Gizmos.DrawWireSphere(transform.position, radiusSpawnRocket);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            isPlayerEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            isPlayerEnter = false;
        }
    }
}
