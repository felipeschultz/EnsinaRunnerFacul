using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : EnsinaRunnerController
{
    public DatabaseConnection myDB;
    public GameObject questionPrefab;
    public int selectedTheme;
    public Dictionary<int, string> questionList;
    public CountdownQuestions cq;

    public Transform spawnMin, spawnMax;

    public void Awake()
    {
        selectedTheme = SelectTheme.themeValue;
        questionList = new Dictionary<int, string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        var teste = myDB.ExecuteQuery("SELECT * FROM [Perguntas] WHERE [FK_ID_Temas] = " + selectedTheme);

        while (teste.Read())
        {
            questionList.Add(teste.GetInt32(0), teste.GetString(1));
        }
    }

    #region Teste

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        AskQuestion();
    //    }
    //}

    #endregion

    public void AskQuestion()
    {
        GameObject pergunta = GameObject.Instantiate(questionPrefab);

        var retornoDaLista = Random.Range(0, questionList.Keys.Count);
        var keyRandom = questionList.Keys.ToList()[retornoDaLista];
        var perguntaAtual = questionList[keyRandom];

        questionList.Remove(keyRandom);

        var perguntaController = pergunta.GetComponent<AnswerController>();
        perguntaController.UpdateTextQuestion(perguntaAtual);

        var query = myDB.ExecuteQuery("SELECT * FROM [Respostas] WHERE [FK_ID_Perguntas] = " + keyRandom);

        int index = 0;

        while (query.Read())
        {
            perguntaController.CreateAnswer(index, query.GetString(1), query.GetBoolean(2));
            index++;
        }
    }
}