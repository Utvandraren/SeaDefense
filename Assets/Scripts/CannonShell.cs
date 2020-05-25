using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShell : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    private Vector3 direction;
    [SerializeField] float lifeTime;
    [SerializeField] int damage;
    [SerializeField] ParticleSystem impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        direction = new Vector3(0f, 0f, bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);

        //if(direction.magnitude <= bulletSpeed * Time.deltaTime)
            
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //collision.GetContact(0).point;
        if (collision.collider.transform.tag == "Enemy")
        {
            collision.collider.transform.GetComponent<Health>().TakeDamage(damage);
        }

        ParticleSystem instObj = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(instObj, 6f);
        Destroy(gameObject);
    }

    //void HitTarget()
    //{
    //    if (collision.transform.tag == "Enemy")
    //    {
    //        collision.transform.GetComponent<Health>().TakeDamage(damage);
    //    }
    //    Debug.Log("HitBOOOMM!!!");
    //    Instantiate(impactEffect, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //}

    
}
