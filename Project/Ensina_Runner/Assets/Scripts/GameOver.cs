using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnCollision(Collider2D other)
    {
        if (other.gameObject.tag == "BoxTeste")
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Quiz");
    }
}
