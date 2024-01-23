using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera main, second;

    private bool mainEnabled;

    private void Start()
    {
        second.enabled = false;
        mainEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            mainEnabled = !mainEnabled;
            main.enabled = mainEnabled;
            second.enabled = !mainEnabled;
        }
    }
}
