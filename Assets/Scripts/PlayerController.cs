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

    [SerializeField]
    float maximumHealth = 300.0F;

    [SerializeField]
    float currentHealth = 0.0F;

    [SerializeField]
    private List<GameObject> corazones;

    [SerializeField]
    private Sprite corazonDesativado;

    [SerializeField]
    private Sprite corazonActivar;

    private SoundController soundController;

    [SerializeField]
    GameObject PanelGameOver;

    private bool isBoosted = false;


    [SerializeField]
    Animator animator;

    Rigidbody2D rb;

    Vector2 direction;

    [SerializeField]
    Vector2 lastDirection;

    [SerializeField]
    TextMeshProUGUI SpeedCount;

    [SerializeField]
    TextMeshProUGUI HeartCompleCount;

  

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        soundController = FindObjectOfType<SoundController>();

        collectibles =
           new Dictionary<string, int>()
           {
                { SPEED, 0},
                { COIN, 0 },
                { FORCE, 0 },
                { HEARTCOMPLETE, 0 }
           };


    }

    public void TakeDamage(float value)
    {
        animator.SetTrigger("hurt");
        currentHealth -= Mathf.Abs(value);

        if (currentHealth < 100.0f)
        {
            BajarVida(1);
            soundController.PlaySound("BajarVida");
        }
        else if (currentHealth < 300.0f)
        {
            BajarVida(2);
            soundController.PlaySound("BajarVida");
        }

        if (currentHealth <= 0.0F)
        {
            BajarVida(0);
            soundController.PlaySound("BajarVida");
            animator.SetTrigger("die");
            StartCoroutine(EsperarMuerte());
        }
    }

    public void BajarVida(int indice)
    {
        Image imgCorazon = corazones[indice].GetComponent<Image>();
        imgCorazon.sprite = corazonDesativado;
        imgCorazon.color = new Color32(85, 85, 85, 255);
        

    }

    public void RecuperarVida(int indice)
    {
        
        Image imgCorazon = corazones[indice].GetComponent<Image>();
        imgCorazon.sprite = corazonActivar;
        imgCorazon.color = new Color32(255, 0, 0, 255);
        soundController.PlaySound("BoostHeal");


    }


    void Start()
    {
        currentHealth = maximumHealth;
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
            soundController.PlaySound("BoostSpeed");

            // Inicia la corutina para devolver la velocidad a su valor inicial
            StartCoroutine(ReturnToNormalSpeed());
        }
    }
    public void HeartComple()
    {
        // Verifica si el valor de HeartCompleCount es mayor o igual a 1
        if (int.TryParse(HeartCompleCount.text, out int count) && count >= 1)
        {
            // Incrementa el valor al maximumHealth
            currentHealth = maximumHealth;
            RecuperarVida(1);
            RecuperarVida(2);
            RecuperarVida(0);

            // Resta uno al valor de HeartCompleCount
            HeartCompleCount.text = (count - 1).ToString();

            
        }
    }

    IEnumerator EsperarMuerte()
    {
        yield return new WaitForSeconds(2.0f);
        PanelGameOver.SetActive(true);
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
