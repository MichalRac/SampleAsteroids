using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int TotalScore { get; private set; }
    public int HighScore { get; private set; }

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
            Destroy(this);
        }
    }

    public void AddScore(int value)
    {
        TotalScore += value;
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
    }
}
