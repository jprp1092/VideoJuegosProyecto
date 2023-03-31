using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]
    string collectibleType;

    [SerializeField]
    int value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            PlayerController controller = 
                other.GetComponent<PlayerController>();
            if (controller != null) 
            {           
                controller.IncreaseCollectible(collectibleType, value);
            }
            Destroy(gameObject);
        }
    }


}
