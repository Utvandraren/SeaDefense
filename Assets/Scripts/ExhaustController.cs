using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] exhaustRockets = new ParticleSystem[4];
    public float weight;

    // Start is called before the first frame update
    void Start()
    {
        weight = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            weight += 0.6f;
        }

        EmitRockets();
    }

    void EmitRockets()
    {
        for (int i = 0; i < exhaustRockets.Length; i++)
        {
            exhaustRockets[i].Emit((int)weight);
            
        }

        weight -= 0.3f;
        weight = Mathf.Clamp(weight, 1f, 800f);


    }
}
