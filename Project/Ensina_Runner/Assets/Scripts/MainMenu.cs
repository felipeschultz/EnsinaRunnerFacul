#region Explicação da Classe
/*
 * Classe criada para a cena de menu principal, Está classe tem os métodos dos botões <Start>, <Ranking>, <Sair>.
*/
#endregion

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : EnsinaRunnerController
{
    public string startGameLevel;
    public string startRankingLevel;
    public InputField inputNickname;
    public static string nickname;

    // Método para o Botão <Start>
    public void StartGame()
    {
        //nickname = inputNickname.text;

        //if (string.IsNullOrEmpty(inputNickname.text))
        //{
        //    SSTools.ShowMessage("Verifique o Nickname!", SSTools.Position.bottom, SSTools.Time.twoSecond);

        //    return;
        //}
        //if (SelectTheme.themeValue == 0)
        //{
        //    SSTools.ShowMessage("Selecione um Tema!", SSTools.Position.bottom, SSTools.Time.twoSecond);

        //    return;
        //}
        //else
        {
            SceneManager.LoadScene(startGameLevel);
        }
    }

    // Método para o botão <Ranking>
    public void RankingGame()
    {
        SceneManager.LoadScene(startRankingLevel);
    }

    // Método para o Botão <Sair>
    public void SairGame()
    {
        Application.Quit();
    }
}