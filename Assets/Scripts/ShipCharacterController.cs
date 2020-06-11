using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCharacterController : MonoBehaviour
{
    Animator animator;
    ExhaustController rocketController;
    Rigidbody rigid;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rocketController = GetComponentInChildren<ExhaustController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
        HandleMovement();
        //Set movement based on horizontal and vertikal input
    }

    public void HandleMovement()
    {
        direction.z = -Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        rigid.AddForce(direction * 40f);
        direction = Vector3.zero;

       
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
