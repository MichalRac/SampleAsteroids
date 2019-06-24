using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _wrapArea;
    [SerializeField] private GameObject _asteroidSpawner;
    private int _triesLeft = 3;
    /*
    private GameObject _playerHolder;
    private GameObject _wrapAreaHolder;
    private GameObject _asteroidSpawnerHolder;
    */


    private void Awake()
    {
        Debug.Assert(_player.GetComponent<PlayerController>(), "Non player object referenced");
        Debug.Assert(_wrapArea.GetComponent<LevelBounds>(), "Non LevelBounds object referenced");
        Debug.Assert(_asteroidSpawner.GetComponent<AsteroidSpawner>(), "Non Spawner object referenced");

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void BeginGame()
    {
         // Reusing the fields but removing the from inspector during runtime
        _player = Instantiate(_player);
        _wrapArea = Instantiate(_wrapArea);
        _asteroidSpawner = Instantiate(_asteroidSpawner);

        /*
        // Not reusing fields, just a bit bigger space complexity but not removing references from inspector during runtime
        _playerHolder = Instantiate(_player);
        _wrapAreaHolder = Instantiate(_wrapArea);
        _asteroidSpawnerHolder = Instantiate(_asteroidSpawner);
        */
    }

    public void OnLostLife()
    {
        _triesLeft--;
        if (_triesLeft > 0)
        {
            SetActiveMainObjects(false);
            StartCoroutine(RestartGame());
        }
        else if (_triesLeft == 0)
        {
            StopGame();
        }
        else
        {
            Debug.LogError("Incorrect TriesLeft Value");
            StopGame();
        }
    }

    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2.0f);
        SetActiveMainObjects(true);
    }

    public void SetActiveMainObjects(bool setBool)
    {
        _player.SetActive(setBool);
        _wrapArea.SetActive(setBool);
        _asteroidSpawner.SetActive(setBool);
    }


    public void StopGame()
    {
        Debug.Log("Game Finished");
        SetActiveMainObjects(false);
    }

}
