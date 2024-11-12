using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteFactoryBlueEnemy : EnemyFactory
{
    [SerializeField]
    private BlueEnemy BlueEnemyPrefab;

    public override IEnemy GetEnemy(Vector3 position)
    {
        GameObject instance = Instantiate(BlueEnemyPrefab.gameObject, position, Quaternion.identity);
        BlueEnemy newEnemy = instance.GetComponent<BlueEnemy>();

        newEnemy.Spawn();

        return newEnemy;
    }
}
