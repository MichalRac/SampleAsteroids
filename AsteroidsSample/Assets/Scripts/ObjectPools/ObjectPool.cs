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
        Debug.Log("Expanding Pool");
        for (int i = 0; i < expandByValue; i++)
        {
            var instanceToAdd = Instantiate(pooledObject);
            instanceToAdd.transform.SetParent(transform);

            IPoolable instanceInterface = instanceToAdd.GetComponent<IPoolable>();
            Debug.Assert(instanceInterface != null, $"The assigned obstacle GameObject {instanceToAdd.name} does not have IPoolable interface");
            instanceInterface.Pool = this;

            ReturnToPool(instanceToAdd);
        }
    }

    public override void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
        pool.Enqueue(instance);
    }
}
