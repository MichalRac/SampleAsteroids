using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings Prefab", menuName = "Data Prefabs/Initial Settings")]
public class GameInitData : ScriptableObject
{
    public bool collisionBetweenAsteroids;
    public int numberOfLives = 3;
    public int scorePerAsteroid = 1;
    [Range(50, 1000)]
    public float playerBaseSpeed = 100;
    [Range(50, 1000)]
    public float playerRotation = 300;
    [Range(1.3f, 2.0f)]
    public float boltSpeedMultiplier = 1.3f;
    [Range(0.1f, 2.0f)]
    public float asteroidSpeedMultiplier = 0.8f;
}
