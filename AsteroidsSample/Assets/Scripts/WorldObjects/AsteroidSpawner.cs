﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] _asteroidTypes;
    [SerializeField] private float _timeToFirstSpawn;
    private const float ASTEROID_SPAWN_OFFSET = 1.2f;
    public float timeBetweenSpawns;
    private Vector3 randomSpawnPoint;


    private void OnEnable()
    {
        StartCoroutine(asteroidSpawner());
    }

    private void OnDisable()
    {
        StopCoroutine(asteroidSpawner());
    }

    public IEnumerator asteroidSpawner()
    {
        yield return new WaitForSeconds(_timeToFirstSpawn);

        while(true)
        {

            switch ((int)Random.Range(0, 4))
            {
                case 0:
                    randomSpawnPoint = new Vector3(LevelBounds.horExtent, 0.0f, Random.Range(-LevelBounds.verExtent, LevelBounds.verExtent));
                    break;
                case 1:
                    randomSpawnPoint = new Vector3(-LevelBounds.horExtent, 0.0f, Random.Range(-LevelBounds.verExtent, LevelBounds.verExtent));
                    break;
                case 2:
                    randomSpawnPoint = new Vector3(Random.Range(-LevelBounds.horExtent, LevelBounds.horExtent), 0.0f, LevelBounds.verExtent);
                    break;
                case 3:
                    randomSpawnPoint = new Vector3(Random.Range(-LevelBounds.horExtent, LevelBounds.horExtent), 0.0f, -LevelBounds.verExtent);
                    break;
            }
            randomSpawnPoint = randomSpawnPoint * ASTEROID_SPAWN_OFFSET; // Hardcoded offset
            Instantiate(_asteroidTypes[Random.Range(0, _asteroidTypes.Length)], randomSpawnPoint, Quaternion.Euler(Vector3.zero));
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

}