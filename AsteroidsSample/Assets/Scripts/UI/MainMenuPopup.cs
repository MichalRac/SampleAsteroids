using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuPopup : BasicPopup
{
    [SerializeField] protected Text highScore;

    private void OnEnable()
    {
        setText();
    }

    public override void setText()
    {
        highScore.text = $"Highscore: {ScoreManager.Instance.HighScore}";
    }

    public void OnPlayButtonClicked()
    {
        GameManager.Instance.BeginGame();
    }
}
