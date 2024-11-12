using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeEnemy : MonoBehaviour, IEnemy
{
    public new string name { get; set; }
    public float health { get; set; }
    public float speed { get; set; }

    private void Awake()
    {
        name = "Orange Enemy";
        health = 50f;
        speed = 4f;
    }

    private void Update()
    {
        transform.Translate(new Vector3(1f, 0f, 0f) * 2f * Time.deltaTime, Space.Self);
    }

    public void Spawn()
    {
        Debug.Log(name + health + speed);
    }
}
