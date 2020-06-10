using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCharacterController : MonoBehaviour
{
    Animator animator;
    ExhaustController rocketController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rocketController = GetComponentInChildren<ExhaustController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
        //Set movement based on horizontal and vertikal input
    }

    public void Move()
    {
        
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
