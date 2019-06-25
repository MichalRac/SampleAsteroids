using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : BasePool
{
    //Main Obstacles, the place on the array is the obstacleIndexID
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
        ExpandPool(10);
    }

    public override GameObject GetPooledObject()
    {
        int randIndex = Random.Range(0, obstaclePools.Count);

        if (obstaclePools[randIndex].Count == 0)
        {
            ExpandPool(10);
        }

        var instance = obstaclePools[randIndex].Dequeue();
        instance.SetActive(true);
        return instance;
    }

    public GameObject GetNextIndexObject(int currentObstacleID)
    {
        if (currentObstacleID < obstaclePools.Count)
        {
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
                Debug.Log(obstacleIndex);

                ReturnToPool(instanceToAdd);
            }
        }
    }

    //Expanding a particular obstacle pool
    protected void ExpandObstaclePool(int expandedObstacleIndex, int expandByValue)
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
        Debug.Log(instance.GetComponent<IPoolableObstacle>().ObstacleID);
        obstaclePools[instance.GetComponent<IPoolableObstacle>().ObstacleID].Enqueue(instance);
    }
}
