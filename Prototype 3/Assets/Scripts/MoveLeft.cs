using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10;
    private PlayerController playerControllerScript;
    private float leftBound = -15f;
    private float originalSpeed;
    private GameStartAnimation gameStartAnimation;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameStartAnimation = GameObject.Find("Player").GetComponent<GameStartAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false && gameStartAnimation.walkEnded)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if(Input.GetKey(KeyCode.E))
        {
            speed = originalSpeed * 2;
        }
        else
        {
            speed = originalSpeed;
        }
    }
}
