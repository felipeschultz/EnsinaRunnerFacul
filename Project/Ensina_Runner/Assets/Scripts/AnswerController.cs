using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerController : EnsinaRunnerController
{
    public Text textQuestionController;
    public List<ToggleController> toggleController;

    void Start()
    {
        PauseGame();
    }

    void Pause()
    {
        ResumeGame();
    }

    public void UpdateTextQuestion(string textQuestion)
    {
        textQuestionController.text = textQuestion;
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void CreateAnswer(int index, string text, bool isCorrect)
    {
        toggleController[index].SetAnswer(text, isCorrect);
    }
}