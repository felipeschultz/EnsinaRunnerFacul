using UnityEngine;
using UnityEngine.UI;

public class ToggleController : EnsinaRunnerController
{
    public bool isCorrectController;
    public Text textAnswer;
    public Text answerCorrect;
    public int answerCorrectCount;

    public void OnSelect(bool change)
    {
        if (isCorrectController)
        {
            Destroy(GameObject.Find("Perguntas(Clone)"));
            AnswerController.ResumeGame();
        }
    }

    public void SetAnswer(string answer, bool isCorrect)
    {
        this.isCorrectController = isCorrect;
        textAnswer.text = answer;
    }
}