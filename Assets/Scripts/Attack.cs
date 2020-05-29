using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent),typeof(Animator))]
public class Attack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Transform target;
    [SerializeField] float attackCoolDown;

    Animator animator;
    NavMeshAgent agent;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        animator = transform.GetComponent<Animator>();

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
        animator.SetBool("isAttacking", true);
        //Debug.Log("Attack");
    }

    public void DealDamageAnimEvent()
    {
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
