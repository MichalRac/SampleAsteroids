using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{

    public static ObjectPoolManager Instance { get; private set; }
    
    [SerializeField] private ObjectPool boltPool;
    [SerializeField] private AsteroidPool asteroidPool;
    public ObjectPool BoltPool { get => boltPool; private set => boltPool = value; }
    public AsteroidPool AsteroidPool { get => asteroidPool; private set => asteroidPool = value; }

    private void Awake()
    {
        Debug.Assert(boltPool, "Bolt pool script was not assigned");
        Debug.Assert(asteroidPool, "Asteroid pool script was not assigned");
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Destroying illegal instance of ObjectPoolManager singleton");
            Destroy(gameObject);
        }
        AsteroidPool = Instantiate(asteroidPool);
        BoltPool = Instantiate(boltPool);
    }

    public static void DisableAllPooledObjects()
    {
        // A little dirty way to go about it, would be a pain if there were many different pools, maybe there is a way to go about it in more generic way?
        // TODO: Look into adding DisableChildPoolObjects from the level of separate pools, >>> or even adding it to main BasicPool and just calling that method in each used pool <<<
        DisableObstaclePoolChilds(Instance.AsteroidPool.transform);

        Transform pool = Instance.BoltPool.transform;
        for (int i = 0; i < pool.childCount; i++)
        {
            Instance.BoltPool.ReturnToPool(pool.GetChild(i).gameObject);
        }
    }

    public static void DisableObstaclePoolChilds(Transform pool)
    {
        for (int i = 0; i < pool.childCount; i++)
        {
            Instance.AsteroidPool.ReturnToPool(pool.GetChild(i).gameObject);
        }
    }
}
