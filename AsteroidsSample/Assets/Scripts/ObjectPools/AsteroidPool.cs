﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : BasePool
{
    //Main Obstacles, the place on the array is the obstacleIndexID
    //Via GetNextIndexObject, the first obstacle might spawn second, second might spawn third, last will not spawn anything (should be easy to extend)
    [SerializeField] private GameObject[] obstacles;
    
    //Dictionary of different types of obstacles
    //The Key is connected to obsctacleIndexID, the value is a pool queue of objects created from obstacles[obstacleIndexID]
    private Dictionary<int, Queue<GameObject>> obstaclePools = new Dictionary<int, Queue<GameObject>>();

    private void Awake()
    {
        for(int i = 0; i < obstacles.Length; i++)
        {
            obstaclePools.Add(i, new Queue<GameObject>());
        }
        ExpandPool(10); // Adding 10 of each obstacle to the pool
    }

    public override GameObject GetPooledObject()
    {
        int randIndex = Random.Range(0, obstacles.Length);
        GameObject instance = null;
        try
        {
            if (obstaclePools[randIndex].Count == 0)
            {
                ExpandObstacleIndexInPool(randIndex, 5);
            }

            instance = obstaclePools[randIndex].Dequeue();
            
        }
        catch(KeyNotFoundException)
        {
            Debug.Log("PooledObject not found");
            return null;
        }
        
        return instance;
    }

    public GameObject GetNextIndexObject(int currentObstacleID)
    {
        if (currentObstacleID < obstaclePools.Count)
        {
            if (obstaclePools[currentObstacleID + 1].Count == 0)
            {
                ExpandObstacleIndexInPool(currentObstacleID + 1, 5);
            }

            var instance = obstaclePools[currentObstacleID + 1].Dequeue();
            instance.SetActive(true);
            return instance;
        }
        else
        {
            return null;
        }
    }

    // In this case we expand entire pool of all obstacles
    protected override void ExpandPool(int expandByValue)
    {
        // nested loops, ew
        for (int obstacleIndex = 0; obstacleIndex < obstacles.Length; obstacleIndex++)
        {
            for (int i = 0; i < expandByValue; i++)
            {
                var instanceToAdd = Instantiate(obstacles[obstacleIndex]);
                instanceToAdd.transform.SetParent(transform);

                IPoolableObstacle instanceInterface = instanceToAdd.GetComponent<IPoolableObstacle>();
                Debug.Assert(instanceInterface != null, $"The assigned obstacle GameObject {obstacles[obstacleIndex].name} does not have IPoolableObstacle interface");
                instanceInterface.Pool = this;
                instanceInterface.ObstacleID = obstacleIndex;

                ReturnToPool(instanceToAdd);
            }
        }
    }

    //Expanding a particular obstacle pool
    protected void ExpandObstacleIndexInPool(int expandedObstacleIndex, int expandByValue)
    {
        for (int i = 0; i < expandByValue; i++)
        {
            var instanceToAdd = Instantiate(obstacles[expandedObstacleIndex]);
            instanceToAdd.transform.SetParent(transform);

            IPoolableObstacle instanceInterface = instanceToAdd.GetComponent<IPoolableObstacle>();
            Debug.Assert(instanceInterface != null, $"The assigned obstacle GameObject {obstacles[expandedObstacleIndex].name} does not have IPoolableObstacle interface");
            instanceInterface.Pool = this;
            instanceInterface.ObstacleID = expandedObstacleIndex;

            ReturnToPool(instanceToAdd);
        }
    }

    public override void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
        obstaclePools[instance.GetComponent<IPoolableObstacle>().ObstacleID].Enqueue(instance);
    }
}
