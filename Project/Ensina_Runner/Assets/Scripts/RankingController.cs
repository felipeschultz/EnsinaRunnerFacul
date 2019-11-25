using System.Collections.Generic;
using UnityEngine;

public class RankingController : EnsinaRunnerController
{
    public List<Player> players;
    public GameObject rankingPrefab;
    public Transform canvasTransform;
    public DatabaseConnection myDB;

    // Start is called before the first frame update
    void Start()
    {
        SelectPlayers();
        UpdateRanking();
    }

    private void SelectPlayers()
    {
        players = new List<Player>();

        string query = "SELECT * FROM [Player] ORDER BY [Respostas_Corretas] DESC, [Distancia_Percorrida] DESC LIMIT 10";

        var teste = myDB.ExecuteQuery(query);

        while (teste.Read())
        {
            players.Add(new Player() { Nickname = teste.GetString(1), Distance = teste.GetInt32(2), CorrectAnswers = teste.GetInt32(3) });
        }
    }

    private void UpdateRanking()
    {
        for (int i = 0; i < players.Count; i++)
        {
            GameObject rankingRowLocal = GameObject.Instantiate(rankingPrefab);
            rankingRowLocal.GetComponent<RowController>().UpdatePlayer(players[i], i + 1);
        }
    }
}