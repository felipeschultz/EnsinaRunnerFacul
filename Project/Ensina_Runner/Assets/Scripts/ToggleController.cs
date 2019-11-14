using UnityEngine;
using UnityEngine.UI;

public class ToggleController : EnsinaRunnerController
{
    public bool isCorrectController;
    public static bool isCorrectStatic;
    public Text textAnswer;
    public GameObject postDeathPrefabs;

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

            // FAZER UM SELECT DE INSERT NO BANCO DE DADOS PARA AS RESPOSTAS ERRADAS.

            Debug.Log("DISTANCIA: " + DistanceManager.pointsPerSecondsLast);
            Debug.Log("PERGUNTAS CORRETAS: " + AnswerCorrectManager.answerCorrectCountStatic);
            Debug.Log("NICKNAME: " + MainMenu.nickname);
        }
    }

    public void SetAnswer(string answer, bool isCorrect)
    {
        this.isCorrectController = isCorrect;
        textAnswer.text = answer;
    }
}