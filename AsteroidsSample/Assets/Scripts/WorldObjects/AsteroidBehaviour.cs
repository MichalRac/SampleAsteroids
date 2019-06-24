using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : ForwardingObjectsBehaviour, IDestroyable, IScorable
{
    [SerializeField] private GameObject SpawnedObjectOnDestroy;
    [SerializeField] private int scoreValue = 1;
    public int ScoreValue { get => scoreValue; set => scoreValue = value; }
    private const float SPEED_MULTIPLIER_ASTEROID = 0.6f;


    protected override void Start()
    {
        // Moving towards a random point on screen with random rotation
        Vector3 initialTargetPoint = new Vector3(Random.Range(-LevelBounds.horExtent, LevelBounds.horExtent), 0.0f, Random.Range(-LevelBounds.verExtent, LevelBounds.verExtent));
        Vector3 targetMovmentVector = initialTargetPoint - gameObject.transform.position;
        _rb.velocity = targetMovmentVector.normalized * basePlayerMovementSpeed * SPEED_MULTIPLIER_ASTEROID;
        _rb.angularVelocity = Random.rotation.eulerAngles.normalized;
    }

    public void Destroy()
    {
        if(SpawnedObjectOnDestroy != null)
        {
            Instantiate(SpawnedObjectOnDestroy, this.transform.position + new Vector3(5.0f, 0.0f, 5.0f), this.transform.rotation);
            Instantiate(SpawnedObjectOnDestroy, this.transform.position - new Vector3(5.0f, 0.0f, 5.0f), this.transform.rotation);
        }
        Destroy(gameObject);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        IDestroyable destroyableObject = other.GetComponent<IDestroyable>();
        if (destroyableObject != null)
        {
            destroyableObject.Destroy();
        }
    }

    public void Score(int value)
    {
        ScoreManager.Instance.AddScore(value);
    }
}
