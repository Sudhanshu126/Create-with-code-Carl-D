using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public variables
    public Transform player;
    public float horizontalOffset, verticalOfset;

    //private variables
    private Quaternion rotationAngle;

    void LateUpdate()
    {
        //get camera's rotation angle
        rotationAngle = player.rotation;

        //camera follow code
        transform.position = player.position + player.forward * horizontalOffset + Vector3.up * verticalOfset;
        rotationAngle *= Quaternion.Euler(new Vector3(19f, 0f, 0f));
        transform.rotation = rotationAngle;
    }
}
