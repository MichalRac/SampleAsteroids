using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Setting up the UIManager Singleton
    public static UIManager Instance { get; private set; }
    [SerializeField] private BasicPopup MainMenuPopup;
    [SerializeField] private BasicPopup GameFinishedPopup;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text triesText;


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
            Destroy(gameObject);
        }
        MainMenuPopup = Instantiate(MainMenuPopup, transform);
        GameFinishedPopup = Instantiate(GameFinishedPopup, transform);
        scoreText = Instantiate(scoreText, transform);
        triesText = Instantiate(triesText, transform);
    }

    private void Start()
    {
        MainMenuPopup.DisplayPopup(true);
        DisplayIngameUI(false);
    }
    #endregion

    #region Main Control Methods

    public void OnGameStarted()
    {
        DisplayIngameUI(true);
        UpdateScore();
        UpdateTries();
    }

    public void OnGameFinished()
    {
        GameFinishedPopup.DisplayPopup(true);
        DisplayIngameUI(false);
    }

    public void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {ScoreManager.Instance.TotalScore.ToString()}";
        }
    }

    public void UpdateTries()
    {
        if (triesText != null)
        {
            triesText.text = $"Tries left: {GameManager.Instance.TriesLeft.ToString()}";
        }
    }

    #endregion

    #region Helper methods

    public void DisplayIngameUI(bool value)
    {
        scoreText.gameObject.SetActive(value);
        triesText.gameObject.SetActive(value);
    }

    public void showMainMenuPopup()
    {
        MainMenuPopup.DisplayPopup(true);
    }

    #endregion
}
