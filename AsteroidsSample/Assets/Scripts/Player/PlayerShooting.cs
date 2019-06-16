using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bolt;
    [SerializeField] private Transform _boltSpawnPoint;
    private bool _canShoot;
    private float _shootingSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBolt = Instantiate(_bolt, _boltSpawnPoint.position, _boltSpawnPoint.rotation);
        }
    }

    public void OnInputShoot()
    {
        
    }
}
