﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : EnsinaRunnerController
{
    public GameObject postDeathPrefabs;
    public DatabaseConnection myDB;
    public List<string> verifyNicks;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BoxTeste")
        {
            AnswerController.PauseGame();
            GameObject postDeath = GameObject.Instantiate(postDeathPrefabs);

            try
            {
                string queryVerify = $"SELECT * FROM [Player] WHERE [Nickname] = '{MainMenu.nickname}'";

                var verifyNickname = myDB.ExecuteQuery(queryVerify);

                while (verifyNickname.Read())
                {
                    verifyNicks.Add(verifyNickname.GetString(1));
                }

                verifyNicks.Count.ToString();

                if (verifyNicks.Count.Equals(0))
                {
                    Debug.Log("Inserir dados desse Nickname: " + verifyNicks.Count);

                    string query =
                        $"INSERT INTO [Player](ID_Player, Nickname, Distancia_Percorrida, Respostas_Corretas) VALUES(null, '{MainMenu.nickname}', {DistanceManager.pointsPerSecondsLast}, {AnswerCorrectManager.answerCorrectCountStatic})";

                    myDB.ExecuteQuery(query);

                    Debug.Log("DISTANCIA: " + DistanceManager.pointsPerSecondsLast);
                    Debug.Log("PERGUNTAS CORRETAS: " + AnswerCorrectManager.answerCorrectCountStatic);
                    Debug.Log("NICKNAME: " + MainMenu.nickname);
                }
                else
                {
                    Debug.Log("Fazer Update desse nickname: " + verifyNicks.Count);

                    string queryUpdate =
                        $"UPDATE [Player] SET [Distancia_Percorrida] = {DistanceManager.pointsPerSecondsLast}, [Respostas_Corretas] = {AnswerCorrectManager.answerCorrectCountStatic} WHERE [Nickname] = '{MainMenu.nickname}'";

                    myDB.ExecuteQuery(queryUpdate);

                    Debug.Log("DISTANCIA: " + DistanceManager.pointsPerSecondsLast);
                    Debug.Log("PERGUNTAS CORRETAS: " + AnswerCorrectManager.answerCorrectCountStatic);
                    Debug.Log("NICKNAME: " + MainMenu.nickname);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}