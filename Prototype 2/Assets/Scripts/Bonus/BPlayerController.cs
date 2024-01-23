using UnityEngine;

public class BPlayerController : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float speed;
    public float xRange, topRange, bottomRange;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 translationalVector = new Vector3(horizontalInput, 0f, verticalInput);
        if (transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            if(horizontalInput > 0)
            {
                transform.Translate(translationalVector * speed * Time.deltaTime);
            }
        }
        else if(transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            if (horizontalInput < 0)
            {
                transform.Translate(translationalVector * speed * Time.deltaTime);
            }
        }
        if (transform.position.z <= bottomRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomRange);
            if (verticalInput > 0)
            {
                transform.Translate(translationalVector * speed * Time.deltaTime);
            }
        }
        else if (transform.position.x >= topRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topRange);
            if (verticalInput < 0)
            {
                transform.Translate(translationalVector * speed * Time.deltaTime);
            }
        }
        transform.Translate(translationalVector * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(0f, 1f, 0f), projectilePrefab.transform.rotation);
        }
    }
}
