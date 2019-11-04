#region Explicação da Classe
/*
 * Classe criada para a cena de menu principal, Está classe tem os métodos dos botões <Start>, <Ranking>, <Sair>.
*/
#endregion

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : EnsinaRunnerController
{
    public string startGameLevel;

    // Método para o Botão <Start>
    public void StartGame()
    {
        SceneManager.LoadScene(startGameLevel);
    }

    /* Método <Ranking> Não Desenvolvido
    // Função para o Botão <Ranking>
    public void RankingGame()
    {

    }
    */

    // Método para o Botão <Sair>
    public void SairGame()
    {
        Application.Quit();
    }
}