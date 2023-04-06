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
    float speed = 5.0F;
    public float maxSpeed = 10.0f;
    public float initialSpeed = 5.0f;
    public float boostSpeed = 10.0f;

    private bool isBoosted = false;


    [SerializeField]
    Animator animator;

    Rigidbody2D rb;

    Vector2 direction;

    [SerializeField]
    Vector2 lastDirection;

    [SerializeField]
    TextMeshProUGUI SpeedCount;

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

    public void BoostSpeed()
    {
        // Verifica si el valor del TextMeshProUGUI es mayor o igual a 1
        if (int.TryParse(SpeedCount.text, out int count) && count >= 1 && !isBoosted)
        {
            // Aumenta la velocidad del jugador
            speed = boostSpeed;

            // Resta uno al valor del TextMeshProUGUI
            SpeedCount.text = (count - 1).ToString();

            // Inicia la corutina para devolver la velocidad a su valor inicial
            StartCoroutine(ReturnToNormalSpeed());
        }
    }

    IEnumerator ReturnToNormalSpeed()
    {
        isBoosted = true;
        yield return new WaitForSeconds(5.0f); // Espera 5 segundos
        speed = initialSpeed; // Restablece la velocidad inicial
        isBoosted = false;
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
