using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] Animator animator;

    public override void Die()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject, 20f);

        base.Die();
    }
}
