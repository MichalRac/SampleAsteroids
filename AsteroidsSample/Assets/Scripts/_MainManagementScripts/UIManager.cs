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
    }

    private void Start()
    {
        MainMenuPopup.DisplayPopup(true);
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

    public void OnGameFinished()
    {
        GameFinishedPopup.DisplayPopup(true);
    }

    public void showMainMenuPopup()
    {
        MainMenuPopup.DisplayPopup(true);
    }
    #endregion
}
