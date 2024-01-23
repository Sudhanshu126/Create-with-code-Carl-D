using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        InvokeRepeating("SpawnMinions", 5f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMinions()
    {
        spawnManager.SpawnEnemyWave(2);
    }
}
