using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : ForwardingObjectsBehaviour, IDestroyable, IScorable, IPoolableObstacle
{
    [SerializeField] private GameObject SpawnedObjectOnDestroy;
    [SerializeField] private Particle particleOnDestroy;
    [SerializeField] private int scoreValue = 1;
    [HideInInspector] public int ObstacleID { get; set; }
    public int ScoreValue { get; set; }
    private float SPEED_MULTIPLIER_ASTEROID;


    protected override void Start()
    {
        GetSettingsData();
        // Moving towards a random point on screen with random rotation
        Vector3 initialTargetPoint = new Vector3(Random.Range(-LevelBounds.horExtent, LevelBounds.horExtent), 0.0f, Random.Range(-LevelBounds.verExtent, LevelBounds.verExtent));
        Vector3 targetMovmentVector = initialTargetPoint - gameObject.transform.position;
        _rb.velocity = targetMovmentVector.normalized * basePlayerMovementSpeed * SPEED_MULTIPLIER_ASTEROID;
        _rb.angularVelocity = Random.rotation.eulerAngles.normalized;
    }

    public void GetSettingsData()
    {
        SPEED_MULTIPLIER_ASTEROID = DataSetupManager.Instance.InitData.asteroidSpeedMultiplier;
        scoreValue = DataSetupManager.Instance.InitData.scorePerAsteroid;

    }

    public void DestroyGameObject()
    {
        if(SpawnedObjectOnDestroy != null)
        {
            GameObject spawnedNextObstacle = ObjectPoolManager.Instance.AsteroidPool.GetNextIndexObject(ObstacleID);
            spawnedNextObstacle.transform.position = this.transform.position + new Vector3(10.0f, 0.0f, 10.0f);

            spawnedNextObstacle = ObjectPoolManager.Instance.AsteroidPool.GetNextIndexObject(ObstacleID);
            spawnedNextObstacle.transform.position = this.transform.position - new Vector3(10.0f, 0.0f, 10.0f);

            //Instantiate(SpawnedObjectOnDestroy, this.transform.position + new Vector3(5.0f, 0.0f, 5.0f), this.transform.rotation, AsteroidSpawner.Instance.transform);
            //Instantiate(SpawnedObjectOnDestroy, this.transform.position - new Vector3(5.0f, 0.0f, 5.0f), this.transform.rotation, AsteroidSpawner.Instance.transform);
        }
        ObjectPoolManager.Instance.AsteroidPool.ReturnToPool(this.gameObject);
        Instantiate(particleOnDestroy, transform.position, transform.rotation);
        //Destroy(gameObject);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        IDestroyable destroyableObject = other.GetComponent<IDestroyable>();
        if (destroyableObject != null)
        {
            destroyableObject.DestroyGameObject();
        }
    }

    public void Score()
    {
        ScoreManager.Instance.AddScore(scoreValue);
    }
}
