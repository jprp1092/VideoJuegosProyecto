using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRadius;

    [SerializeField]
    float damage;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            animator.SetTrigger("melee");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void OnAttack() 
    {
        Collider2D[] colliders = 
            Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        foreach (Collider2D collider in colliders) 
        {
            if (!collider.CompareTag("Player"))
            {
                HealthController healthController = collider.GetComponent<HealthController>();
                if (healthController != null)
                {
                    healthController.TakeDamage(damage);
                }
            }
        }
    }

}
