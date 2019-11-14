using UnityEngine;
using UnityEngine.SceneManagement;

public class PostDeathMenu : EnsinaRunnerController
{
    public string startGameLevel;

    public void RestartGame()
    {
        SceneManager.LoadScene(startGameLevel);
        AnswerController.ResumeGame();
    }

    public void RankingGame()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}