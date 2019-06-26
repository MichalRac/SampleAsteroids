using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameFinishedPopup : BasicPopup
{
    [SerializeField] protected Text highScore;
    [SerializeField] protected Text totalScore;

    private void OnEnable()
    {
        setText();
    }

    public override void setText()
    {
        highScore.text = $"Highscore: {ScoreManager.Instance.HighScore}";
        totalScore.text = $"Score: {ScoreManager.Instance.TotalScore}";
    }

    public void OnPlayAgainButtonClicked()
    {
        GameManager.Instance.BeginGame();
    }

    public void OnMainMenuButtonClicked()
    {
        UIManager.Instance.showMainMenuPopup();
    }
}
