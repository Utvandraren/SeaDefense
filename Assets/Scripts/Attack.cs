using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Attack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Transform target;
    [SerializeField] float attackCoolDown;
    NavMeshAgent agent;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0)
        {
            elapsedTime = attackCoolDown;

            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= agent.stoppingDistance)
            {
                AttackTarget();
            }
        }
    }

    void AttackTarget()
    {
        //Animation.play
        Debug.Log("Attack");
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
