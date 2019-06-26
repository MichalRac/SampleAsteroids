using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody _bolt;
    [SerializeField] private Transform _boltSpawnPoint;
    [SerializeField] private ObjectPool _boltPool;
    private Rigidbody rb;
    private bool _canShoot;
    private float _shootingSpeed;

    private void Awake()
    {
        _boltPool = Instantiate(_boltPool); 
        rb = GetComponent<Rigidbody>();
        Debug.Assert(_boltPool, "ObjectPool intended for BoltPool not referenced");
        Debug.Assert(rb, "Rigidbody reference issue");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBolt = ObjectPoolManager.Instance.BoltPool.GetPooledObject();
            newBolt.transform.position = _boltSpawnPoint.position;
            newBolt.transform.rotation = _boltSpawnPoint.rotation;

            BoltBehaviour newBoltBehaviour = newBolt.GetComponent<BoltBehaviour>();
            newBoltBehaviour.ResetVelocityDirection();
        }
    }

    public void OnInputShoot()
    {
        
    }
}
