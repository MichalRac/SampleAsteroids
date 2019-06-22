using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _wrapArea;
    [SerializeField] private GameObject _asteroidSpawner;

    private void Awake()
    {
        Debug.Assert(_player.GetComponent<PlayerController>(), "Wrong game object referenced");
        Debug.Assert(_wrapArea.GetComponent<LevelBounds>(), "Wrong game object referenced");
        //Debug.Assert(_asteroidSpawner.GetComponent<>(), "Wrong game object referenced");

    }

    private void Start()
    {
        Instantiate(_player);
        Instantiate(_wrapArea);
        //Instantiate(_asteroidSpawner);
    }
}
