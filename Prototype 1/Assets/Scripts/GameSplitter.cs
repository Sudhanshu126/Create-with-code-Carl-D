using UnityEngine;

public class GameSplitter : MonoBehaviour
{
    public string horizontal, vertical;

    private float horizontalInput, verticalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis(horizontal);
        verticalInput = Input.GetAxis(vertical);

        //player movement forward
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        //player movement rotation
        if (verticalInput > 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
            transform.Rotate(-Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }
}
