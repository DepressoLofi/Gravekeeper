using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteFactoryGreenEnemy : EnemyFactory
{
    [SerializeField]
    private GreenEnemy GreenEnemyPrefab;

    public override IEnemy GetEnemy(Vector3 position)
    {
        GameObject instance = Instantiate(GreenEnemyPrefab.gameObject, position, Quaternion.identity);
        GreenEnemy newEnemy = instance.GetComponent<GreenEnemy>();

        newEnemy.Spawn();

        return newEnemy;
    }

}
