using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody _bolt;
    [SerializeField] private Transform _boltSpawnPoint;
    private Rigidbody rb;
    private bool _canShoot;
    private float _shootingSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody newBolt = Instantiate(_bolt, _boltSpawnPoint.position, _boltSpawnPoint.rotation);
            newBolt.velocity = rb.velocity;
        }
    }

    public void OnInputShoot()
    {
        
    }
}
