using System.Collections.Generic;
using UnityEngine;

public class RankingController : EnsinaRunnerController
{
    public List<Player> players;
    public GameObject rankingPrefab;
    public Transform canvasTransform;

    public Transform canvas1;
    public Transform canvas2;

    // Start is called before the first frame update
    void Start()
    {
        SelectPlayers();
        UpdateRanking();

        Debug.Log(Vector2.Distance(canvas1.position, canvas2.position));
    }

    private void SelectPlayers()
    {
        players = new List<Player>();
        players.Add(new Player() { CorrectAnswers = 0, Distance = 999, Nickname = "Lobinho" });
        players.Add(new Player() { CorrectAnswers = 1, Distance = 1, Nickname = "Lhaminha" });
        players.Add(new Player() { CorrectAnswers = 2, Distance = 2, Nickname = "Moikinha" });
        players.Add(new Player() { CorrectAnswers = 3, Distance = 3, Nickname = "Joycinha" });
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