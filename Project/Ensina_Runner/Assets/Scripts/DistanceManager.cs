#region Explicação da Classe
/*
    Classe criada para fazer o gerenciamento dos pontos do jogador, tanto os pontos de "Distância" como os pontos de "Respostas Corretas".
*/
#endregion

using System;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : EnsinaRunnerController
{
    // Instância para Manipular o Texto DistanciaText da UI.
    public Text DistanceText;
    public float DistanceCount;
    public float PointsPerSeconds;
    public static float pointsPerSecondsLast = 0;

    // Update is called once per frame
    void Update()
    {
        DistanceCount += PointsPerSeconds * Time.deltaTime;
        DistanceText.text = "Distância: " + Math.Round(DistanceCount);

        pointsPerSecondsLast = DistanceCount;
    }
}