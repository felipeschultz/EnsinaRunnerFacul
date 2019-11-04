using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : EnsinaRunnerController
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BoxTeste")
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}