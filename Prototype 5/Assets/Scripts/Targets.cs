using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private Rigidbody rb;
    private float minSpeed = 13f;
    private float maxSpeed = 18f;
    private float maxTorque = 10f;
    private float xRange = 4f, ySpawnPos = -6f;
    private GameManager gameManager;
    [SerializeField] private int pointValue, layer;
    [SerializeField] private ParticleSystem explosionParticle;
    private MouseDrag mouseDrag;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mouseDrag = GameObject.Find("Trail").GetComponent<MouseDrag>();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, layer);
    }

    private void OnMouseEnter()
    {
       if(gameManager.isGameActive && mouseDrag.swiping)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
                gameManager.isGameActive = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            GameManager.life -= 1;
            gameManager.UpdateLife();
            if (GameManager.life == 0)
            {
                gameManager.GameOver();
            }
        }
        Destroy(gameObject);
    }
}
