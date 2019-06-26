using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{

    public static ObjectPoolManager Instance { get; private set; }
    
    [SerializeField] private BasePool boltPool;
    [SerializeField] private AsteroidPool asteroidPool;
    public BasePool BoltPool { get => boltPool; private set => boltPool = value; }
    public AsteroidPool AsteroidPool { get => asteroidPool; private set => asteroidPool = value; }

    private void Awake()
    {
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
    }

    public static void DisableAllPooledObjects()
    {
        DisableObstaclePoolChilds(Instance.AsteroidPool.transform);
        //Not yet connected to ObjectPoolManager
        //DisablePoolChilds(Instance.BoltPool.transform);
    }

    public static void DisableObstaclePoolChilds(Transform pool)
    {
        for (int i = 0; i < pool.childCount; i++)
        {
            Instance.AsteroidPool.ReturnToPool(pool.GetChild(i).gameObject);
        }
    }
}
