using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Score score;

    public Text scoreLabel;
    public Text highScoreLabel;

    private void OnEnable()
    {
        int currentScore = score.GetScore();
        //Debug.Log("Current Score: " + currentScore);
        scoreLabel.text = "Score: " + currentScore;

        //Check highscore
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        highScoreLabel.text = "Highscore: " + highscore;
        if(currentScore > highscore)
            PlayerPrefs.SetInt("highscore", currentScore);

    }

    public void RestartGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    public void CloseGame()
    {
        Application.Quit(); //No se ve en el editor de unity, solo en builds.
    }

}
