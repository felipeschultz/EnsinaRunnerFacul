using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DatabaseConnection myDB;
    public GameObject perguntaPrefab;
    public int temaSelecionado;
    public List<string> listaDePerguntas;

    public void Awake()
    {
        temaSelecionado = SelectTheme.themeValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        myDB.ExecuteQuery("SELECT * FROM Perguntas WHERE FK_ID_Temas = " + temaSelecionado);
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
        var retornoDaLista = Random.Range(0, listaDePerguntas.Count);
        var perguntaAtual = listaDePerguntas[retornoDaLista];

        listaDePerguntas.RemoveAt(retornoDaLista);
        pergunta.GetComponent<PerguntaController>().AtualizarTextoPergunta(perguntaAtual);
    }
}
