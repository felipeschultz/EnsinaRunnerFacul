using UnityEngine;
using UnityEngine.SceneManagement;

public class PostDeathMenu : EnsinaRunnerController
{
    public string startGameLevel;
    public string startRankingLevel;

    public void RestartGame()
    {
        SceneManager.LoadScene(startGameLevel);
        AnswerController.ResumeGame();
        DistanceManager.pointsPerSecondsLast = 0;
        AnswerCorrectManager.answerCorrectCountStatic = 0;
    }

    public void RankingGame()
    {
        SceneManager.LoadScene(startRankingLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}