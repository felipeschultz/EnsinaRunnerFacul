using System;
using System.Data;
using System.IO;
using Mono.Data.SqliteClient;
using UnityEngine;

public class DatabaseConnection : EnsinaRunnerController
{
    private IDbConnection connection;
    private IDbCommand command;
    private readonly string dbName = "EnsinaRunner.db";
    private string dbFile;

    public void Awake()
    {
        try
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                dbFile = Application.dataPath + "/StreamingAssets/" + dbName;
            }
            else
            {
                dbFile = Application.persistentDataPath + "/" + dbName;

                if (!File.Exists(dbFile))
                {
                    Debug.LogWarning("File \"" + dbFile + "\" does not exist. Attempting to create from \"" +
                                     Application.dataPath + "!/assets/" + dbName);
                    
                    WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + dbName);

                    while (!load.isDone) { }

                    File.WriteAllBytes(dbFile, load.bytes);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        ConnectionDB();
    }

    // método de conexão
    public void ConnectionDB()
    {
        try
        {
            connection = new SqliteConnection("URI=file:" + dbFile);
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