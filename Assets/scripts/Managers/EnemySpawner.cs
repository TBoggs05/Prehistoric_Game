using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] protected float spawnInterval = 8f;
    [SerializeField] protected GameObject dino_enemy_prefab;
    private int dinosSpawned;
    private int maxDinos = 3;
    private bool spawningAllowed;
    private bool routine_started;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        routine_started = false;
        dinosSpawned = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spawningAllowed = true;
            if(!routine_started)
                StartCoroutine(spawnEnemy(spawnInterval, dino_enemy_prefab));
            Debug.Log("Entered zone: Setting up initial effects.");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spawningAllowed = false;
            Debug.Log("Entered zone: Setting up initial effects.");
        }
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        routine_started = true;
        if (spawningAllowed)
        {
            yield return new WaitForSeconds(interval);
            dinosSpawned = transform.childCount;
            if (dinosSpawned < maxDinos)
            {
                if (!EnemyManager.Instance.enemiesCapped)
                {
                    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-2f, 2f) + gameObject.transform.position.x, Random.Range(-2f, 2f) + gameObject.transform.position.y, -3), Quaternion.identity, gameObject.transform);
                    dinosSpawned++;
                    
                }
                StartCoroutine(spawnEnemy(interval, enemy));
            }
        }
        else
        {
            routine_started = false;
            yield break;
        }
    }
}
