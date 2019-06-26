using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Setting up the ScoreManager Singleton
    public static ScoreManager Instance { get; private set; }
    public int HighScore { get; private set; }
    public int TotalScore { get; private set; }

    private void Awake()
    {
        /*
        HighScore save = Saving.LoadHighScore();
        if(save != null)
        {
            HighScore = save.highScore;
        }
        */

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Destroying illegal instance of ScoreManager singleton");
            Destroy(gameObject);
            UIManager.Instance.UpdateScore();

        }
        
    }
    #endregion

    private void Start()
    {
        OnGameInitialStart();
    }

    #region Main ScoreManager timestamp methods
    public void OnGameInitialStart()
    {
        TotalScore = 0;
        HighScore = 0;
        //Load the HighScore here
    }

    public void OnPlayerDestroyed()
    {

    }

    public void OnGameFinished()
    {
        CheckHighScore();
    }
    #endregion

    #region Main ScoreManager methods
    public void AddScore(int value)
    {
        TotalScore += value;
        Debug.Log($"TotalScore {TotalScore}, {value}");
        UIManager.Instance.UpdateScore();
    }

    public void CheckHighScore()
    {
        if (TotalScore > HighScore)
        {
            HighScore = TotalScore;
        }
    }

    public void ResetScore()
    {
        TotalScore = 0;
        UIManager.Instance.UpdateScore();
    }
    #endregion
}
