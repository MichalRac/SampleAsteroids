using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; };
    private static int totalScore;
    private static int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Destroying illegal instance of ScoreManager singleton");
            Destroy(this);
        }
    }

    public static void AddScore(int value)
    {
        totalScore += value;
    }

    public static void CheckHighScore()
    {
        if (totalScore > highScore)
        {
            highScore = totalScore;
        }
    }
}
