using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteEnemyOrangeEnemy : EnemyFactory
{
    [SerializeField]
    private OrangeEnemy OrangeEnemyPrefab;

    public override IEnemy GetEnemy(Vector3 position)
    {
        GameObject instance = Instantiate(OrangeEnemyPrefab.gameObject, position, Quaternion.identity);
        OrangeEnemy newEnemy = instance.GetComponent<OrangeEnemy>();

        newEnemy.Spawn();

        return newEnemy;
    }
}
