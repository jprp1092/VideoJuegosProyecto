using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    float maximumHealth = 100.0F;

    [SerializeField]
    float currentHealth = 0.0F;

    [SerializeField]
    private List<GameObject> corazones;

    [SerializeField]
    private Sprite corazonDesativado;

    void Start()
    {
        currentHealth = maximumHealth;
    }
    public void TakeDamage(float value)
    {
        currentHealth -= Mathf.Abs(value);

        if (currentHealth < 100.0f)
        {
            BajarVida(1);
        } else if (currentHealth < 300.0f)
        {
            BajarVida(2);
        }

        if (currentHealth <= 0.0F)
        {
            BajarVida(0);
            Destroy(gameObject);
        }
    }

    public void BajarVida(int indice)
    {
        Image imgCorazon = corazones[indice].GetComponent<Image>();
        imgCorazon.sprite = corazonDesativado;
        imgCorazon.color = new Color32(85, 85, 85, 255);
    }
}
