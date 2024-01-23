using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAnimation : MonoBehaviour
{
    public Animator playerAnimator;
    public bool walkEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!walkEnded)
        {
            if (transform.position.x < 0f)
            {
                Debug.Log("Walk");
                transform.Translate(Vector3.forward * 5f * Time.deltaTime, Space.Self);
            }
            else
            {
                transform.position = Vector3.zero;
                walkEnded = true;
                StopWalk();
            }
        }

    }

    void StopWalk()
    {
        playerAnimator.SetBool("GameBegin", true);
    }
}
