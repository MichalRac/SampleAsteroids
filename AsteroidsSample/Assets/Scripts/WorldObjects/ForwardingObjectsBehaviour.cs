using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ForwardingObjectsBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rb.velocity = _rb.transform.forward * _movementSpeed;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }

    
}
