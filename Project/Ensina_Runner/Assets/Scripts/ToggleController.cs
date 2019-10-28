using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public bool isCorrect;
    public Text textAnswer; 

    public void OnSelect(bool change)
    {
        Debug.Log(isCorrect);
    }

    public void SetAnswer(string answer, bool isCorrect)
    {
        this.isCorrect = isCorrect;
        textAnswer.text = answer;
    }
}
