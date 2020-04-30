using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 3f;
    public float spawnDelay = 4f;

    public GameObject enemy;
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
