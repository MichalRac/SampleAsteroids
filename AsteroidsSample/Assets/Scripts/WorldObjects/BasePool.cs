using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePool : MonoBehaviour
{
    public virtual GameObject GetPooledObject()
    {
        return null;
    }

    protected virtual void ExpandPool(int expandByValue)
    {

    }


    public virtual void ReturnToPool(GameObject instance)
    {
        
    }
}
