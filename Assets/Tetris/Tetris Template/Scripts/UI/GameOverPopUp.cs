using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameOverPopUp : MonoBehaviour {

    public Text gameOverScore;
    
    void OnEnable()
    {
        gameOverScore.text = Managers.Score.currentScore.ToString();
        Managers.UI.panel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
