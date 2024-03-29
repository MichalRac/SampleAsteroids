﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ForwardingObjectsBehaviour : MonoBehaviour, IPoolable
{
    [SerializeField] public static float basePlayerMovementSpeed;  // The base speed is defined as Player Movement Speed
    public BasePool Pool { get; set; }
    protected Rigidbody _rb;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected virtual void Start()
    {
        _rb.velocity = transform.forward * basePlayerMovementSpeed;
    }

    public void ResetVelocityDirection()
    {
        _rb.velocity = _rb.velocity.magnitude * transform.forward;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }

    
}
