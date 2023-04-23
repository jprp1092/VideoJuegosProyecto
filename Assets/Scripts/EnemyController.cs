using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float distance = 1f;

    [SerializeField]
    private LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator anim;

    
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Lanzar un raycast hacia abajo para detectar el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, whatIsGround);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Mover el enemigo si está en el suelo
        if (isGrounded)
        {
            rb.velocity = new Vector2((-transform.right).x * speed, rb.velocity.y);
        }

        // Actualizar la animación
        anim.SetFloat("moveX", rb.velocity.x);
        anim.SetFloat("moveY", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distance);
    }

    void Flip()
    {
        transform.Rotate(0.0F, 180.0F, 0.0F);
    }
}
