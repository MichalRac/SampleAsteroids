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


    protected virtual void ReturnToPool(GameObject instance)
    {
        
    }
}
