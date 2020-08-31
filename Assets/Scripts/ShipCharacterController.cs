using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCharacterController : MonoBehaviour
{
    Animator animator;
    ExhaustController rocketController;
    Rigidbody rigid;
    Vector3 direction;
    float weight;

    // Start is called before the first frame update
    void Start()
    {
        weight = 0f;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rocketController = GetComponentInChildren<ExhaustController>();
        direction = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
        HandleMovement();
        HandleRotation();
    }

    public void HandleMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            weight += 0.3f;
        }

        direction.x += weight;
        //direction.z = -Input.GetAxisRaw("Horizontal") * transform.forward.x;
        //direction.y = Input.GetAxisRaw("Vertical") * transform.forward.y;
        rigid.AddRelativeForce(direction * 40f);
        direction = Vector3.zero;

        weight -= 0.2f;
        weight = Mathf.Clamp(weight, 2f, 200f);
    }

    void HandleRotation()
    {
        float mouseDeltaX;
        float mouseDeltaY;

        mouseDeltaX = Input.GetAxis("Mouse X");
        mouseDeltaY = Input.GetAxis("Mouse Y");
     
        transform.Rotate(0f, mouseDeltaX, mouseDeltaY);

    }

    void UpdateAnimation()
    {
        float blendWeight;
        blendWeight = rocketController.weight;
        blendWeight = (blendWeight - 1) / (5 - 1);
        //blendWeight *= 100f;
        Mathf.Clamp(blendWeight, 0f, 1f);
        animator.SetFloat("Blend", blendWeight);
    }
}
