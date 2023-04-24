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

    private SoundController soundController;

    void Start()
    {
        currentHealth = maximumHealth;
    }

    private void Awake()
    {
        soundController = FindObjectOfType<SoundController>();
    }

    public void TakeDamage(float value)
    {
        currentHealth -= Mathf.Abs(value);
        if (currentHealth <= 0.0F)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Boss"))
            { 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
        }
    }
}