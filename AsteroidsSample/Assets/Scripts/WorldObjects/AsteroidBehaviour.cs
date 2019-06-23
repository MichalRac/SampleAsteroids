using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : ForwardingObjectsBehaviour, IDestroyable
{
    [SerializeField] private GameObject SpawnedObjectOnDestroy;
    private const float SPEED_MULTIPLIER_ASTEROID = 0.8f;

    // Start is called before the first frame update
    protected override void Start()
    {
        // Moving towards a random point on screen
        Vector3 initialTargetPoint = new Vector3(Random.Range(-LevelBounds.horExtent, LevelBounds.horExtent), 0.0f, Random.Range(-LevelBounds.verExtent, LevelBounds.verExtent));
        Vector3 targetMovmentVector = initialTargetPoint - gameObject.transform.position;
        _rb.velocity = targetMovmentVector.normalized * basePlayerMovementSpeed * SPEED_MULTIPLIER_ASTEROID;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        if(SpawnedObjectOnDestroy != null)
        {
            Instantiate(SpawnedObjectOnDestroy, this.transform.position, this.transform.rotation);
            Instantiate(SpawnedObjectOnDestroy, this.transform.position, this.transform.rotation);
        }
        else
        {
            Debug.Log($"No object to spawn on {gameObject.name} being destroyed");
        }
        Destroy(gameObject);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        IDestroyable destroyableObject = other.GetComponent<IDestroyable>();
        if (destroyableObject != null)
        {
            destroyableObject.Destroy();
            Destroy();
        }

    }

}
