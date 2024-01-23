using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool canSpawn = true;

    private void Start()
    {
        InvokeRepeating("SpawnReset", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            canSpawn = false;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }

    void SpawnReset()
    {
        canSpawn = true;
    }
}
