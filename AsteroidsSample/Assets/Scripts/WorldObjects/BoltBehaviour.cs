using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoltBehaviour : ForwardingObjectsBehaviour, IDestroyable
{
    [SerializeField] private Particle particleOnDestroy;
    // To ensure that in case of bullets the bullet is faster than the ship
    private float BASE_SPEED_MULTIPLIER_BOLT; 

    protected override void Start()
    {
        GetSettingsData();
        _rb.velocity = (_rb.velocity + transform.forward * basePlayerMovementSpeed) * BASE_SPEED_MULTIPLIER_BOLT;
    }

    public void GetSettingsData()
    {
        BASE_SPEED_MULTIPLIER_BOLT = DataSetupManager.Instance.InitData.boltSpeedMultiplier;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        IScorable scoreableObject = other.GetComponent<IScorable>();
        if (scoreableObject != null)
        {
            scoreableObject.Score();
        }

        IDestroyable destroyableObject = other.GetComponent<IDestroyable>();
        if (destroyableObject != null)
        {
            destroyableObject.DestroyGameObject();
            DestroyGameObject();
        }
    }

    public void DestroyGameObject()
    {
        Pool.ReturnToPool(gameObject);
        Instantiate(particleOnDestroy, transform.position, transform.rotation);
    }

}