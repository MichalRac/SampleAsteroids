using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Setting up the UIManager Singleton
    public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject MainMenuPopup;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;


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
    #endregion

    #region Main Control Methods
    public void UpdateScore()
    {
        if(scoreText != null)
        {
            scoreText.text = $"Score: {ScoreManager.Instance.TotalScore.ToString()}";
        }
    }

    public void UpdateHighScore()
    {
        if (highScoreText != null)
        {
            highScoreText.text = $"Highscore: {ScoreManager.Instance.HighScore.ToString()}";
        }
    }

    public void OnGameFinished()
    {
        ScoreManager.Instance.CheckHighScore();
        MainMenuPopup.SetActive(true);
        UpdateHighScore();
    }
    #endregion
}
