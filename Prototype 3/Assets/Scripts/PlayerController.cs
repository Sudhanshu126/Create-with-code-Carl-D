using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnimator;
    public float gravityModifier;
    public float jumpForce = 10f;
    private int jumpCount = 0;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && jumpCount<2)
        {
            jumpCount++;
            playerRB.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1f);
            playerAnimator.SetTrigger("Jump_trig");
            dirtSplatter.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            if (!gameOver)
            {
                dirtSplatter.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1f);
            if (!gameOver)
            {
                explosionParticle.Play();
            }
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            dirtSplatter.Stop();
        }
    }
}
