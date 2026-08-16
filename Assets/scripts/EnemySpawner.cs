using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] protected float spawnInterval = 7f;
    [SerializeField] protected GameObject dino_enemy_prefab;
    private int dinosSpawned;
    private int maxDinos = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dinosSpawned = 0;
        StartCoroutine(spawnEnemy(spawnInterval, dino_enemy_prefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        dinosSpawned = transform.childCount;
        if (dinosSpawned < maxDinos)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-2f, 2f) + gameObject.transform.position.x, Random.Range(-2f, 2f)+gameObject.transform.position.y, -3), Quaternion.identity, gameObject.transform);
            dinosSpawned++;
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
