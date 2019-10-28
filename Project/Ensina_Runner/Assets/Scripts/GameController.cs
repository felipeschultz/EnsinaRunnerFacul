using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DatabaseConnection myDB;
    public GameObject perguntaPrefab;
    public int temaSelecionado;
    public Dictionary<int, string> listaDePerguntas;

    public void Awake()
    {
        temaSelecionado = SelectTheme.themeValue;

        listaDePerguntas = new Dictionary<int, string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (temaSelecionado <= 0)
        {
            temaSelecionado = 2;
        }

        var teste = myDB.ExecuteQuery("SELECT * FROM Perguntas WHERE FK_ID_Temas = " + temaSelecionado);

        while (teste.Read())
        {
            listaDePerguntas.Add(teste.GetInt32(0), teste.GetString(1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FazerPergunta();
        }
    }

    public void FazerPergunta()
    {
        GameObject pergunta = GameObject.Instantiate(perguntaPrefab);
        var retornoDaLista = Random.Range(0, listaDePerguntas.Keys.Count);
        var keyRandom = listaDePerguntas.Keys.ToList()[retornoDaLista];
        var perguntaAtual = listaDePerguntas[keyRandom];

        listaDePerguntas.Remove(keyRandom);

        var perguntaController = pergunta.GetComponent<PerguntaController>();
        perguntaController.AtualizarTextoPergunta(perguntaAtual);

        var query = myDB.ExecuteQuery("SELECT * FROM Respostas WHERE FK_ID_Perguntas = " + keyRandom);

        int index = 0;

        while (query.Read())
        {
            perguntaController.CreateAnswer(index, query.GetString(1), query.GetBoolean(2));
            index++;
        }
    }
}
