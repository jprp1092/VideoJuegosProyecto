using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRadius;

    [SerializeField]
    float damage= 15.0F;
    private bool isBoosted = false;
    public float initialdamage = 15.0f;
    public float boostdamage = 25.0f;

    [SerializeField]
    TextMeshProUGUI ForceCount;

    Animator animator;

    public void BoostDamage()
    {
        // Verifica si el valor del TextMeshProUGUI es mayor o igual a 1
        if (int.TryParse(ForceCount.text, out int count) && count >= 1 && !isBoosted)
        {
            // Aumenta la fuerza del jugador
            damage = boostdamage;

            // Resta uno al valor del TextMeshProUGUI
            ForceCount.text = (count - 1).ToString();

            // Inicia la corutina para devolver la velocidad a su valor inicial
            StartCoroutine(ReturnToNormalDamage());
        }
    }

    IEnumerator ReturnToNormalDamage()
    {
        isBoosted = true;
        yield return new WaitForSeconds(5.0f); // Espera 5 segundos
        damage = initialdamage; // Restablece la velocidad inicial
        isBoosted = false;
    }


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
