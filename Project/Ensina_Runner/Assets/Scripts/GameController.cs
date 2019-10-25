using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DatabaseConnection myDB;
    public int tema;
    public GameObject perguntaPrefab;
    public List<string> listaDePerguntas;

    // Start is called before the first frame update
    void Start()
    {
        myDB.ExecuteQuery("SELECT * FROM Perguntas WHERE ID_Temas = " + tema);
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
