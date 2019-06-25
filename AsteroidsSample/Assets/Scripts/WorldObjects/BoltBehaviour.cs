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
        IScorable scoreableObject = other.GetComponent<IScorable>();
        if (scoreableObject != null)
        {
            scoreableObject.Score(scoreableObject.ScoreValue);
        }

        IDestroyable destroyableObject = other.GetComponent<IDestroyable>();
        if (destroyableObject != null)
        {
            destroyableObject.DestroyGameObject();
            DestroyGameObject();
            Debug.Log($"{name} destroyed on collision with {other.name}");
        }
    }

    public void DestroyGameObject()
    {
        Pool.ReturnToPool(gameObject);
    }

}