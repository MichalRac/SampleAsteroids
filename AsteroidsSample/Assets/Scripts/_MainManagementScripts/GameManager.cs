using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Setting up the GameManager Singleton

    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _wrapArea;
    [SerializeField] private GameObject _asteroidSpawner;
    [SerializeField] private GameObject _UIManagerPrefab;
    private int _triesTotal;
    private int _triesLeft;
    public int TriesLeft { get => _triesLeft; private set => _triesLeft = value; }
    /*
    private GameObject _playerHolder;
    private GameObject _wrapAreaHolder;
    private GameObject _asteroidSpawnerHolder;
    */


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"Illegal GameManager instance");
            Destroy(gameObject);
        }

        Debug.Assert(_player.GetComponent<PlayerController>(), "Non player object referenced");
        Debug.Assert(_wrapArea.GetComponent<LevelBounds>(), "Non LevelBounds object referenced");
        Debug.Assert(_asteroidSpawner.GetComponent<AsteroidSpawner>(), "Non Spawner object referenced");
        Debug.Assert(_UIManagerPrefab, "Non UIManager referenced");

    }

    private void Start()
    {
        GetSettingsData();;

        Instantiate(_UIManagerPrefab);
        // Reusing the fields but removing the from inspector during runtime
        _player = Instantiate(_player);
        _wrapArea = Instantiate(_wrapArea);
        _asteroidSpawner = Instantiate(_asteroidSpawner);
        SetActiveMainObjects(false);

        
    }

    public void GetSettingsData()
    {
        _triesTotal = DataSetupManager.Instance.InitData.numberOfLives;
        _triesLeft = _triesTotal;

        if (DataSetupManager.Instance.InitData.collisionBetweenAsteroids == true)
        {
            Physics.IgnoreLayerCollision(11, 11, false);
        }
        else
        {
            Physics.IgnoreLayerCollision(11, 11, true);

        }
    }
    #endregion

    #region Main Gameloop Steps

    // Initial Start Game Method, call it on Play Button Clicked
    public void BeginGame()
    {
        ScoreManager.Instance.ResetScore();
        UIManager.Instance.OnGameStarted();
        SetActiveMainObjects(true);

        /*
        // Not reusing fields, just a bit bigger space complexity but not removing references from inspector during runtime
        _playerHolder = Instantiate(_player);
        _wrapAreaHolder = Instantiate(_wrapArea);
        _asteroidSpawnerHolder = Instantiate(_asteroidSpawner);
        */
    }

    // Call each time your ship is destroyed
    public void OnLostLife()
    {
        _triesLeft--;
        ObjectPoolManager.DisableAllPooledObjects();
        UIManager.Instance.UpdateTries();
        if (_triesLeft > 0)
        {
            SetActiveMainObjects(false);
            StartCoroutine(RestartGame());
        }
        else if (_triesLeft == 0)
        {
            OnGameFinished();
        }
        else
        {
            Debug.LogError("Incorrect TriesLeft Value");
            OnGameFinished();
        }
    }

    // Called when number of tries drops to 0
    public void OnGameFinished()
    {
        Debug.Log("Game Finished");
        SetActiveMainObjects(false);
        ScoreManager.Instance.OnGameFinished();
        UIManager.Instance.OnGameFinished();
        _triesLeft = _triesTotal;
        //Saving.SaveHighScore(ScoreManager.Instance.HighScore);
    }
    #endregion

    #region Helper methods
    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2.0f);
        UIManager.Instance.OnGameStarted();
        SetActiveMainObjects(true);
    }

    public void SetActiveMainObjects(bool setBool)
    {
        _player.SetActive(setBool);
        _wrapArea.SetActive(setBool);
        _asteroidSpawner.SetActive(setBool);
    }
    #endregion
}
