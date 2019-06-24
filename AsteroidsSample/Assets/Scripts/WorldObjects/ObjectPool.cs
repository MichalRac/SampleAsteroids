using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject pooledObject;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public GameObject GetPooledObject()
    {
        if(pool.Count == 0)
        {
            ExpandPool(10);
        }
        var instance = pool.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    public void ExpandPool(int expandByValue)
    {
        for(int i = 0; i < expandByValue; i++)
        {
            var instanceToAdd = Instantiate(pooledObject);
            instanceToAdd.transform.SetParent(transform);
            instanceToAdd.GetComponent<IPoolable>().Pool = this;
            ReturnToPool(instanceToAdd);
        }
    }

    public void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
        pool.Enqueue(instance);
    }
}
