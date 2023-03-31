using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAnimation : MonoBehaviour
{
    [SerializeField]
    float jumpHeight = 0.1f;

    [SerializeField]
    float jumpDuration = 0.5f;

    void Start()
    {
        StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {
        while (true)
        {
            Vector3 startPos = transform.position;
            float elapsedTime = 0.0f;

            while (elapsedTime < jumpDuration)
            {
                elapsedTime += Time.deltaTime;
                float progress = elapsedTime / jumpDuration;
                float xOffset = jumpHeight * Mathf.Sin(progress * Mathf.PI);
                transform.position = startPos + new Vector3(xOffset, 0.0f, 0.0f);
                yield return null;
            }

            transform.position = startPos;
        }
    }
}

