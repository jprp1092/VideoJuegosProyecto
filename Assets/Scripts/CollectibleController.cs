using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]
    string collectibleType;

    [SerializeField]
    int value;

    private SoundController soundController;

    private void Awake()
    {
        soundController = FindObjectOfType<SoundController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            PlayerController controller = 
                other.GetComponent<PlayerController>();
            if (controller != null) 
            {           
                controller.IncreaseCollectible(collectibleType, value);
                soundController.PlaySound("RecogerItem");
            }
            Destroy(gameObject);
        }
    }


}
