using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float zoomForce = 4;
    [SerializeField] float movementTime = 2;
    [SerializeField] float zoomTime = 2;


    [SerializeField] Vector3 dragStartPosition;
    [SerializeField] Vector3 dragCurrentPosition;
    [SerializeField] Transform cameraTransform;


    Vector3 newPosition;
    Vector3 ZoomPosition;
    Vector2 oldMousePosition = Vector2.zero;
    Vector2 deltaMouseMovement;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        newPosition = transform.position;
        ZoomPosition = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //ZoomPosition.z = Input.mouseScrollDelta.y * zoomForce;        
        //transform.position = transform.localToWorldMatrix.MultiplyPoint(ZoomPosition);

        HandleMouseInput();

    }

    

    void HandleMouseInput()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            ZoomPosition.z += Input.mouseScrollDelta.y * zoomForce;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray,out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }

        if (Input.GetMouseButton(1))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);
                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, ZoomPosition, Time.deltaTime * zoomTime);

    }
}
