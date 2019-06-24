﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private Text scoreText;

    private void Awake()
    {
        Debug.Assert(scoreText, "Reference to UI element displaying score was not set");
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Destroying illegal instance of UIManager singleton");
            Destroy(this);
        }
    }

    public void UpdateScore()
    {
        if(scoreText != null)
        {
            scoreText.text = $"Score: {ScoreManager.Instance.TotalScore.ToString()}";
        }
    }
}
