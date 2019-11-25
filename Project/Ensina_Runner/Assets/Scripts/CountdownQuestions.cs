using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CountdownQuestions : MonoBehaviour
{
    public Text countdownQuestionText;
    public int countdownTimer;

    // Update is called once per frame
    void Update()
    {
        //TestTimer();
    }

    public void TestTimer()
    {
        for (int i = countdownTimer; i >= 0; i--)
        {
            countdownQuestionText.text = countdownTimer.ToString();

            Task.Delay(1000);

            countdownTimer--;
        }
    }
}