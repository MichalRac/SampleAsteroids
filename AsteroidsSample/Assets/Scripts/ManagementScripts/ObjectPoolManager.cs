using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{

    public static ObjectPoolManager Instance { get; private set; }
    
    [SerializeField] private BasePool boltPool;
    [SerializeField] private AsteroidPool asteroidPool;
    public BasePool BoltPool { get => boltPool; }
    public AsteroidPool AsteroidPool { get => asteroidPool; }

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
        Instantiate(asteroidPool);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
