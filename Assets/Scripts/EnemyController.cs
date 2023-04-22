using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    [SerializeField]
    float speed;

    [SerializeField]
    float distance;

    [SerializeField]
    LayerMask whatIsGround;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D raycastHit2D =
            Physics2D.Raycast(transform.position, -transform.right, distance,whatIsGround);

        if (!raycastHit2D)
        {
            Flip();
        }

        rb.velocity = new Vector2((-transform.right).x * speed, rb.velocity.y);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, -transform.right * distance);
    }

    void Flip()
    {
       
        transform.Rotate(0.0F, 180.0F, 0.0F);
  
    }
}
