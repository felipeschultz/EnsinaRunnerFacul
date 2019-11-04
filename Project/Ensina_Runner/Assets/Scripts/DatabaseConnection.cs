using System;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine;

public class DatabaseConnection : EnsinaRunnerController
{
    private IDbConnection connection;
    private IDbCommand command;
    //private IDataReader reader;

    private string dbFile;

    public void Awake()
    {
        dbFile = "URI=file:" + Application.dataPath + "/Database/EnsinaRunner.db";
        ConnectionDB();
    }

    // método de conexão
    public void ConnectionDB()
    {
        try
        {
            connection = new SqliteConnection(dbFile);
            command = connection.CreateCommand();
            connection.Open();

            //string testeTable = "CREATE TABLE IF NOT EXISTS TesteJao(id INTEGER PRIMARY KEY AUTOINCREMENT, nomeJao VARCHAR(255) NOT NULL)";
            //string testeTable = "INSERT INTO TesteJao(id, nomeJao) VALUES(1,'TESTE JOAO')";
            //command.CommandText = testeTable;
            //command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IDataReader ExecuteQuery(string query)
    {
        command.CommandText = query;
        return command.ExecuteReader();
    }
}