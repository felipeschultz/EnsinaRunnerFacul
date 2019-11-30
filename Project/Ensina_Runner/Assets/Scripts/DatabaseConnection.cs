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
        dbFile = "URI=file:" + Application.dataPath + "/StreamingAssets/EnsinaRunner.db";
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