using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maximumHealth = 100.0F;

    [SerializeField]
    float currentHealth = 0.0F;
    void Start()
    {
        currentHealth = maximumHealth;
    }
    public void TakeDamage(float value)
    {
        currentHealth -= Mathf.Abs(value);
        if (currentHealth <= 0.0F)
        {
            Destroy(gameObject);
        }
    }
}