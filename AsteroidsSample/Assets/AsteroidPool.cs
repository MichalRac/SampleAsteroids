using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    Dictionary<int, Queue<GameObject>> obstaclePools
        = new Dictionary<int, Queue<GameObject>>();

    private void Awake()
    {
        for(int i = 0; i < obstacles.Length; i++)
        {
            obstaclePools.Add(i, new Queue<GameObject>());
        }
    }
}
