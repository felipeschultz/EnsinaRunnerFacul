using UnityEngine;

public class GameOver : EnsinaRunnerController
{
    public GameObject postDeathPrefabs;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BoxTeste")
        {
            AnswerController.PauseGame();
            GameObject postDeath = GameObject.Instantiate(postDeathPrefabs);

            Debug.Log("DISTANCIA: " + DistanceManager.pointsPerSecondsLast);
            Debug.Log("PERGUNTAS CORRETAS: " + AnswerCorrectManager.answerCorrectCountStatic);
            Debug.Log("NICKNAME: " + MainMenu.nickname);
        }
    }
}