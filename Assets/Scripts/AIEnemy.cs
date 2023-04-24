using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{

    [SerializeField]
    GameObject player;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float speed;

    [SerializeField]
    float distance;

    Rigidbody2D rb;

    Vector2 direction;

    // ATTACK

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRadius;

    bool nextAttack = true;

    [SerializeField]
    float damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    void FixedUpdate()
    {
        HandleMove();
    }

    void HandleMove()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;

        HandleAnimator();

        // Solo movemos al enemigo si el jugador está lo suficientemente cerca
        if (distance < 5f)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (distance < 1.5F)
            {
                if (nextAttack)
                {
                    float seconds = 0.0F;
                    animator.SetTrigger("attack");
                    nextAttack = false;
                    if (transform.CompareTag("Boss"))
                    {
                        seconds = 3.5F;
                    } 
                    else if (transform.CompareTag("Minion"))
                    {
                        seconds = 1.0F;
                    }
                    else if (transform.CompareTag("Sword"))
                    {
                        seconds = 2.0F;
                    }
                    StartCoroutine(Esperar(seconds));
                }
            }
        }
    }

    public void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                PlayerController healthController = collider.GetComponent<PlayerController>();
                if (healthController != null)
                {
                    healthController.TakeDamage(damage);
                }
            }
        }
    }

    void HandleAnimator()
    {
        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);
        animator.SetFloat("speed", direction.sqrMagnitude);
    }

    IEnumerator Esperar(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        nextAttack = true;
    }
}
