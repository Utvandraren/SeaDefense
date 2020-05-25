using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int currentHealth;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
        Debug.LogFormat(currentHealth.ToString() + " " + transform.name.ToString());

    }

    void Die()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject,20f);
        //Play DeathEffects;
    }
}
