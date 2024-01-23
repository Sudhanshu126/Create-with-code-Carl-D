using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject targetEnemy;
    private float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy != null && targetEnemy.transform.position.y > 0f)
        {
            Vector3 moveDirection = (targetEnemy.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(moveDirection);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
