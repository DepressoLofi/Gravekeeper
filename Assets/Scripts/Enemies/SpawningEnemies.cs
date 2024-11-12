using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    public Transform spawnPoint;
    public float spawnInterval = 5f;

    [SerializeField]
    private EnemyFactory[] factories;


    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }


    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            EnemyFactory selectedFactory = factories[Random.Range(0, factories.Length)];
            selectedFactory.GetEnemy(spawnPoint.position);
            yield return new WaitForSeconds(spawnInterval);
        }

    }
}
