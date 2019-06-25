using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : BasePool
{
    [SerializeField] private GameObject pooledObject;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public override GameObject GetPooledObject()
    {
        if(pool.Count == 0)
        {
            ExpandPool(10);
        }
        var instance = pool.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    protected override void ExpandPool(int expandByValue)
    {
        for(int i = 0; i < expandByValue; i++)
        {
            var instanceToAdd = Instantiate(pooledObject);
            instanceToAdd.transform.SetParent(transform);
            instanceToAdd.GetComponent<IPoolable>().Pool = this;
            ReturnToPool(instanceToAdd);
        }
    }

    protected override void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
        pool.Enqueue(instance);
    }
}
