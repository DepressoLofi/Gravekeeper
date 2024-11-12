using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public string name { get; set; }
    public float health { get; set; }
    public float speed { get; set; }

    public void Spawn();
   
}
