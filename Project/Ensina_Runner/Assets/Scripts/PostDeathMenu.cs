using UnityEngine;
using UnityEngine.SceneManagement;

public class PostDeathMenu : EnsinaRunnerController
{
    public string startGameLevel;

    public void RestartGame()
    {
        SceneManager.LoadScene(startGameLevel);
        AnswerController.ResumeGame();
        DistanceManager.pointsPerSecondsLast = 0;
        AnswerCorrectManager.answerCorrectCountStatic = 0;
    }

    public void RankingGame()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}