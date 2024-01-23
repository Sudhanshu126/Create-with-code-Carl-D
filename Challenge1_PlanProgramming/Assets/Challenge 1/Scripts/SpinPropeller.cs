using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    private float rotationSpeed = 1000f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f), rotationSpeed * Time.deltaTime);
    }
}
