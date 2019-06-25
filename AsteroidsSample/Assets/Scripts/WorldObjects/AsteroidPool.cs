using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : BasePool
{
    [SerializeField] private GameObject[] obstacles;

    private Dictionary<int, Queue<GameObject>> obstaclePools
        = new Dictionary<int, Queue<GameObject>>();

    private void Awake()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstaclePools.Add(i, new Queue<GameObject>());
        }
    }

    protected override void ExpandPool(int expandByValue)
    {
        for (int i = 0; i < expandByValue; i++)
        {
            var instanceToAdd = Instantiate(obstacles[i]);
            instanceToAdd.transform.SetParent(transform);
            instanceToAdd.GetComponent<IPoolable>().Pool = this;
            ReturnToPool(instanceToAdd);
        }
    }
}
