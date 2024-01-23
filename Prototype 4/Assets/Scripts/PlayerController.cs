using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRb;
    public Transform focalPoint;
    private bool hasPowerup1 = false;
    private float powerupStrength = 20f;
    public GameObject powerupIndicator1;
    public float bulletSpawnOffset;
    public static bool isAlive = true;
    public GameObject bulletPrefab;
    public Canvas gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float sidewayInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = (focalPoint.forward * forwardInput + focalPoint.right * sidewayInput).normalized;
        playerRb.AddForce(moveDirection * speed * Time.deltaTime, ForceMode.VelocityChange);
        powerupIndicator1.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
        
        if(transform.position.y < -10f)
        {
            gameOverCanvas.enabled = true;
            isAlive = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup1"))
        {
            hasPowerup1 = true;
            Destroy(other.gameObject);
            powerupIndicator1.SetActive(true);
            StartCoroutine(Powerup1CountdownRoutine());
        }
        else if (other.CompareTag("Powerup2"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Powerup2CountdownRoutine());
        }
        else if (other.CompareTag("Powerup3"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Powerup3CountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup1)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator Powerup1CountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup1 = false;
        powerupIndicator1.SetActive(false);
    }

    IEnumerator Powerup2CountdownRoutine()
    {
        SpawnHomingMissiles();
        yield return new WaitForSeconds(0.5f);
        SpawnHomingMissiles();
        yield return new WaitForSeconds(0.5f);
        SpawnHomingMissiles();
    }

    IEnumerator Powerup3CountdownRoutine()
    {
        playerRb.AddForce(Vector3.up * 40f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.2f);
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(Vector3.down * 50f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.2f);
        HeavyAttack();
        yield return new WaitForSeconds(0.3f);

        playerRb.AddForce(Vector3.up * 40f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.2f);
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(Vector3.down * 50f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.2f);
        HeavyAttack();
        yield return new WaitForSeconds(0.3f);

        playerRb.AddForce(Vector3.up * 40f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.2f);
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(Vector3.down * 50f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.2f);
        HeavyAttack();
    }

    void SpawnHomingMissiles()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Vector3 bulletDirection = (enemy.transform.position - transform.position).normalized;
            Vector3 spawnPosition = transform.position + bulletDirection * bulletSpawnOffset;
            bulletPrefab.transform.rotation = Quaternion.LookRotation(bulletDirection);
            GameObject spawnedBullet =  Instantiate(bulletPrefab, spawnPosition, bulletPrefab.transform.rotation);
            spawnedBullet.GetComponent<Bullet>().targetEnemy = enemy;
        }
    }

    void HeavyAttack()
    {
        float attackRange = 7.5f;

        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, attackRange);

        foreach(Collider enemy in enemiesInRange)
        {
            if (enemy.gameObject.CompareTag("Enemy"))
            {
                Vector3 awayFromPlayer = (enemy.gameObject.transform.position - transform.position).normalized;
                enemy.gameObject.GetComponent<Rigidbody>().AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
        }
    }
}
