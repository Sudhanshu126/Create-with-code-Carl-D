using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private char mode;
    private Vector3 rotationAxis;
    float hue;
    Color newColor;
    bool scaleUp;
    float scale = 1f;

    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        transform.localScale = Vector3.one * scale;
        hue = 0f;
        newColor = Color.HSVToRGB(hue, 1f, 0.8f);
        Renderer.material.color = newColor;
        mode = 'x';
        rotationAxis = Vector3.left;
        InvokeRepeating("ChangeMode", 0f, 2f);
    }

    private void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(50f * Time.deltaTime, rotationAxis);
        if (hue >= 1f)
        {
            hue = 0f;
        }
        if (scaleUp)
        {
            scale += Time.deltaTime;
            if(scale >= 7.5f)
            {
                scaleUp = false;
            }
        }
        else
        {
            scale -= Time.deltaTime;
            if(scale <= 1f)
            {
                scaleUp = true;
            }
        }
        transform.localScale = Vector3.one * scale;
        hue += 0.1f * Time.deltaTime;
        newColor = Color.HSVToRGB(hue, 1f, 0.8f);
        Renderer.material.color = newColor;
    }

    void ChangeMode()
    {
        if(mode == 'x')
        {
            mode = 'y';
            rotationAxis = Vector3.up;
        }
        else if(mode == 'y')
        {
            mode = 'z';
            rotationAxis = Vector3.forward;
        }
        else if( mode == 'z')
        {
            mode = 'x';
            rotationAxis = Vector3.left;
        }
    }
}
