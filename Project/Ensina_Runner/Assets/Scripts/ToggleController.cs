using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : EnsinaRunnerController
{
    public bool isCorrectController;
    public static bool isCorrectStatic;
    public Text textAnswer;
    public GameObject postDeathPrefabs;
    public DatabaseConnection myDB;

    public void OnSelect(bool change)
    {
        // Debug.Log(isCorrectController);

        if (isCorrectController)
        {
            isCorrectStatic = isCorrectController;
            Destroy(GameObject.Find("Perguntas(Clone)"));
            AnswerController.ResumeGame();
        }
        else
        {
            Destroy(GameObject.Find("Perguntas(Clone)"));
            GameObject postDeath = GameObject.Instantiate(postDeathPrefabs);

            // *************************************************************************************************************************
            //
            // FAZER UM SELECT DE INSERT NO BANCO DE DADOS PARA AS RESPOSTAS ERRADAS.
            // 
            // MELHORAR OS INSERTS NO BANCO E IMPLEMENTAR UM UPDATE JUNTO PARA ATUALIZAR OS PONTOS CASO FOR MAIOR QUE A JOGADA ANTERIOR.
            //
            // *************************************************************************************************************************
            try
            {
                myDB.ExecuteQuery($"INSERT INTO Player (ID_Player, Nickname, Distancia_Percorrida, Respostas_Corretas) VALUES (null, '{MainMenu.nickname}', {DistanceManager.pointsPerSecondsLast}, {AnswerCorrectManager.answerCorrectCountStatic})");

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
    }

    public void SetAnswer(string answer, bool isCorrect)
    {
        this.isCorrectController = isCorrect;
        textAnswer.text = answer;
    }
}