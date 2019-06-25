using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScore : MonoBehaviour
{
    public int highScore = 0;

    public HighScore(int highScore)
    {
        this.highScore = highScore;
    }
}
