using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    float distance;

    Vector3 originalPosition;

    Animator animator;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        originalPosition = transform.position;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.position);
        animator.SetFloat("distance", distance);
        LookAt(target.position);
    }
    public void LookAt(Vector3 point)
    {
        spriteRenderer.flipX = transform.position.x < point.x;
    }
    public Vector3 GetOriginalPosition()
    {
        return originalPosition;
    }
}
