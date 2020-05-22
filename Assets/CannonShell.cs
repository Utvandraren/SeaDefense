using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShell : MonoBehaviour
{
    [SerializeField] Vector3 bulletSpeed;
    [SerializeField] float lifeTime;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletSpeed);
    }
}
