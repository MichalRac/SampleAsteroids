using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner Settings", menuName = "Data Prefabs/Spawner Settings")]
public class SpawnerSettings : ScriptableObject
{
    public float timeToStartSpawning = 2;
    public float timeBetweenSpawns = 2;
}
