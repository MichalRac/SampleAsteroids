using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoltBehaviour : ForwardingObjectsBehaviour, IDestroyable
{
    private const float BASE_SPEED_MULTIPLIER_BOLT = 1.3f; // To ensure that in case of bullets the bullet is faster than the ship
    
    protected override void Start()
    {
        _rb.velocity = (_rb.velocity + transform.forward * basePlayerMovementSpeed) * BASE_SPEED_MULTIPLIER_BOLT;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        IDestroyable destroyableObject = other.GetComponent<IDestroyable>();
        if (destroyableObject != null)
        {
            destroyableObject.Destroy();
            Destroy();
        }

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}