using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownQuestions : EnsinaRunnerController
{
    public Text countdownQuestionText;
    public int countdownTimer;

    void Start()
    {
        Debug.Log("Vou Iniciar!");
        StartCoroutine(TimerPrefab());
    }

    IEnumerator TimerPrefab()
    {
        Debug.Log("Entrou na Corotine");
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("Sai da Corotine!");
        countdownQuestionText.text = (Convert.ToInt32(countdownQuestionText.text) -1).ToString();

        if (countdownQuestionText.text == "0")
        {
            Debug.Log("Morre Mizera!");
        }
        else
        {
            Debug.Log(countdownQuestionText.text);
            StartCoroutine(TimerPrefab());
        }
    }
}