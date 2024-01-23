using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class MouseDrag : MonoBehaviour
{
    private GameManager gameManager;
    private Camera mainCamera;
    private Vector3 mousePosition;
    [SerializeField]private TrailRenderer trail;
    public bool swiping = false;

    private void Awake()
    {
        mainCamera = Camera.main;
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void UpdateMousePosition()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, 10.0f));
        transform.position = mousePosition;
    }

    private void UpdateComponents()
    {
        trail.enabled = swiping;
    }

    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }
            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

}
