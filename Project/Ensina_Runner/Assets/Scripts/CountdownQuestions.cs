using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownQuestions : EnsinaRunnerController
{
    public Text countdownQuestionText;
    public int countdownTimer;
    public GameObject postDeathPrefabs;
    public DatabaseConnection myDB;

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
            Destroy(GameObject.Find("Perguntas(Clone)"));
            GameObject postDeath = GameObject.Instantiate(postDeathPrefabs);

            // *************************************************************************************************************************
            // 
            // MELHORAR OS INSERTS NO BANCO E IMPLEMENTAR UM UPDATE JUNTO PARA ATUALIZAR OS PONTOS CASO FOR MAIOR QUE A JOGADA ANTERIOR.
            //
            // *************************************************************************************************************************
            try
            {
                string query =
                    $"INSERT INTO Player(ID_Player, Nickname, Distancia_Percorrida, Respostas_Corretas) VALUES(null, '{MainMenu.nickname}', {DistanceManager.pointsPerSecondsLast}, {AnswerCorrectManager.answerCorrectCountStatic})";

                myDB.ExecuteQuery(query);

                Debug.Log("DISTANCIA: " + DistanceManager.pointsPerSecondsLast);
                Debug.Log("PERGUNTAS CORRETAS: " + AnswerCorrectManager.answerCorrectCountStatic);
                Debug.Log("NICKNAME: " + MainMenu.nickname);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else
        {
            Debug.Log(countdownQuestionText.text);
            StartCoroutine(TimerPrefab());
        }
    }
}