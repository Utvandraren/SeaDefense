using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraController : MonoBehaviour
{
    [SerializeField] float movementTime = 2;
    [SerializeField] float zoomTime = 2;

    [SerializeField] Transform cameraTransform;

    
    Vector2 oldMousePosition = Vector2.zero;
    Vector2 mousePosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInput();
    }

    void HandleMouseInput()
    {

        if (Input.GetButton("Fire1"))
        {
            oldMousePosition = mousePosition;
            mousePosition = Input.mousePosition;
            cameraTransform.position += new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"),  0f);
            //Get mouseDelta
            //Move camera a certain amount depending on this delta
        }
    }
}
