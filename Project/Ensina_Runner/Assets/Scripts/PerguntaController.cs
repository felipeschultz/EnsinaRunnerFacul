using UnityEngine;
using UnityEngine.UI;

public class PerguntaController : MonoBehaviour
{
    public Text textoDaPergunta;

    void Start()
    {
        PauseGame();
    }

    void Pause()
    {
        ResumeGame();
    }

    public void AtualizarTextoPergunta(string textoPergunta)
    {
        textoDaPergunta.text = textoPergunta;
    }

    private void PauseGame()
    {
        // Lógica de Pausar
    }

    private void ResumeGame()
    {
        // no stop
    }
}
