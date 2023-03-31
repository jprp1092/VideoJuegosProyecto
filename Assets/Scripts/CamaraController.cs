using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float smoothTime = 0.15F;

    Vector3 offset;
    Vector3 vectorZero = Vector3.zero;

    //distancia que hay entre la camara y el personaje
    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref vectorZero, smoothTime * Time.deltaTime);
    }
}
