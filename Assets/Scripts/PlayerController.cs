using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    const string SPEED = "speed";
    const string COIN = "coin";
    const string FORCE = "force";
    const string HEARTCOMPLETE = "heartcomplete";

    IDictionary<string, int> collectibles;


    public UnityEvent<int> OnCoinCountChanged;
    public UnityEvent<int> OnSpeedCountChanged;
    public UnityEvent<int> OnForceCountChanged;
    public UnityEvent<int> OnHeartCompleCountChanged;
    public UnityEvent<string, int> OnInteract;


    [SerializeField]
    Button speedBostButton;

    [SerializeField]
    float speed = 5.0F;

    [SerializeField]
    Animator animator;

    Rigidbody2D rb;

    Vector2 direction;

    [SerializeField]
    Vector2 lastDirection;





    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        collectibles =
           new Dictionary<string, int>()
           {
                { SPEED, 0},
                { COIN, 0 },
                { FORCE, 0 },
                { HEARTCOMPLETE, 0 }
           };


    }





    void Update()
    {
        HandleInputs();
        HandleAnimator();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);


    }

    void HandleInputs()
    {
        lastDirection = direction;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    void HandleAnimator()
    {
        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);
        animator.SetFloat("speed", direction.sqrMagnitude);
    }





    public void IncreaseCollectible(string collectibleType, int value)
    {
        collectibleType = collectibleType.ToLower();
       
        collectibles[collectibleType] += value;
        switch (collectibleType)
        {
            case COIN:
                if (OnCoinCountChanged != null)
                {
                    OnCoinCountChanged.Invoke(collectibles[collectibleType]);
                }
                break;

            case SPEED:
                if (OnSpeedCountChanged != null)
                {
                    OnSpeedCountChanged.Invoke(collectibles[collectibleType]);
                }
                break;

            case FORCE:
                if (OnForceCountChanged != null)
                {
                    OnForceCountChanged.Invoke(collectibles[collectibleType]);
                }
                break;

            case HEARTCOMPLETE:
                if (OnHeartCompleCountChanged != null)
                {
                    OnHeartCompleCountChanged.Invoke(collectibles[collectibleType]);
                }
                break;




        }
    }







}
