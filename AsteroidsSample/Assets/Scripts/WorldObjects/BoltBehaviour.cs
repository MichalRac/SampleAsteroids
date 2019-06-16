using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoltBehaviour : ForwardingObjectsBehaviour, IDestroyable
{

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