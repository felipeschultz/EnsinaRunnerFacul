using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerguntaController : MonoBehaviour
{
    public Text textoDaPergunta;
    public List<ToggleController> toggleController;

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
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void CreateAnswer(int index, string text, bool isCorrect)
    {
        toggleController[index].SetAnswer(text, isCorrect);
    }
}
