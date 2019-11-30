using System;
using System.Data;
using System.IO;
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
        #if UNITY_EDITOR
        if (Application.platform != RuntimePlatform.Android)
        {
            dbFile = "URI=file:" + Application.dataPath + "/StreamingAssets/EnsinaRunner.db";
        }
        #endif
        else
        {
            dbFile = Application.persistentDataPath + "/" + "EnsinaRunner.db";

            if (!File.Exists(dbFile))
            {
                Debug.LogWarning("File \"" + dbFile + "\" does not exist. Attempting to create from \"" +
                                 Application.dataPath + "!/assets/" + "EnsinaRunner.db");

                WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "EnsinaRunner.db");
                while (!load.isDone) { }

                File.WriteAllBytes(dbFile, load.bytes);
            }
        }

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