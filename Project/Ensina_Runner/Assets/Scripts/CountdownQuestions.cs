using System.Threading;
using UnityEngine.UI;

public class CountdownQuestions : EnsinaRunnerController
{
    public Text countdownQuestionText;
    public int countdownTimer;

    void Update()
    {
        //TestTimer();
    }

    public void TestTimer()
    {
        for (int i = countdownTimer; i >= 0; i--)
        {
            countdownQuestionText.text = countdownTimer.ToString();
            Thread.Sleep(1000);
            countdownTimer--;
        }
    }
}