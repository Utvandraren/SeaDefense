using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    float CurrentCoolDown;
    GameObject target;

    [SerializeField] GameObject bullet;
    [SerializeField] float CoolDown;
    [SerializeField] float range;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject rotationObject;
    [SerializeField] ParticleSystem muzzleFlash;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentCoolDown -= Time.deltaTime;

        if (target == null)
        {
            return;
        }

        if (CurrentCoolDown < 0)
        {
            ShootAtTarget(target);
            CurrentCoolDown = CoolDown;
        }

        TurnTowards(target);
        RotateObject();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceEnemey = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceEnemey < shortestDistance)
            {
                shortestDistance = distanceEnemey;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy;
        }
    }

    void TurnTowards(GameObject target)
    {
        Quaternion lookRot = Quaternion.LookRotation(target.transform.position - transform.position);
        Vector3 rot = lookRot.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rot.y, 0f);

    }

    void RotateObject()
    {
        Quaternion lookRot = Quaternion.LookRotation(target.transform.position - rotationObject.transform.position);
        Vector3 rot = Vector3.zero;

        rot.x = lookRot.eulerAngles.x;        
        rotationObject.transform.localEulerAngles = rot;
    }

    void ShootAtTarget(GameObject target)
    {
        muzzleFlash.Play();
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
