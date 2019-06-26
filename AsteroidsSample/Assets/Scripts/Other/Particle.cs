using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private float Lifetime = 2.0f;

    private void Awake()
    {
        Destroy(gameObject, Lifetime);
    }
}
