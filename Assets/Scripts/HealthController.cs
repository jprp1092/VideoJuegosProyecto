using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (gameObject.CompareTag("Boss"))
            {
                Debug.Log("You win!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
        }
    }
}