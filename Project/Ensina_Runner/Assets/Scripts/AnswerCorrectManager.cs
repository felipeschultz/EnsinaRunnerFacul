using UnityEngine.UI;

public class AnswerCorrectManager : EnsinaRunnerController
{
    public int answerCorrectCount = 0;
    public static int answerCorrectCountStatic = 0;
    public Text answerIncrementText;

    // Update is called once per frame
    void Update()
    {
        AnswerTextIncrement();
    }

    public void AnswerTextIncrement()
    {
        if (ToggleController.isCorrectStatic)
        {
            answerCorrectCount++;
            answerCorrectCountStatic = answerCorrectCount;
            answerIncrementText.text = "Respostas Corretas: " + answerCorrectCount;
            ToggleController.isCorrectStatic = false;
        }
    }
}