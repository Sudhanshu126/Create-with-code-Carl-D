using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variables
    public float speed;
    public float turnSpeed;
    public string horizontal, vertical;

    //private variables
    private float horizontalInput;
    private float verticalInput;

    void Update()
    {
        //player input
        horizontalInput = Input.GetAxis(horizontal);
        verticalInput = Input.GetAxis(vertical);

        //player movement forward
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        //player movement rotation
        if(verticalInput > 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
        else if(verticalInput < 0)
        {
            transform.Rotate(-Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }
}
