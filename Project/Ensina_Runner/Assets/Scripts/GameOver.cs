using UnityEngine;

public class GameOver : EnsinaRunnerController
{
    public GameObject postDeathPrefabs;
    public DatabaseConnection myDB;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BoxTeste")
        {
            AnswerController.PauseGame();
            GameObject postDeath = GameObject.Instantiate(postDeathPrefabs);

            try
            {
                // *************************************************************************************************************************
                //
                // FAZER UM SELECT DE INSERT NO BANCO DE DADOS PARA AS RESPOSTAS ERRADAS.
                // 
                // MELHORAR OS INSERTS NO BANCO E IMPLEMENTAR UM UPDATE JUNTO PARA ATUALIZAR OS PONTOS CASO FOR MAIOR QUE A JOGADA ANTERIOR.
                //
                // *************************************************************************************************************************
                string query =
                    $"INSERT INTO Player(ID_Player, Nickname, Distancia_Percorrida, Respostas_Corretas) VALUES(null, '{MainMenu.nickname}', {DistanceManager.pointsPerSecondsLast}, {AnswerCorrectManager.answerCorrectCountStatic})";

                myDB.ExecuteQuery(query);

                Debug.Log("DISTANCIA: " + DistanceManager.pointsPerSecondsLast);
                Debug.Log("PERGUNTAS CORRETAS: " + AnswerCorrectManager.answerCorrectCountStatic);
                Debug.Log("NICKNAME: " + MainMenu.nickname);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}