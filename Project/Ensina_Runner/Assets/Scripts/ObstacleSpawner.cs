using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public List<GameObject> obstaclesToSpawn = new List<GameObject>();

    private int index;

    void Awake()
    {
        InitiObstacle();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomObstacles());
    }

    // Inicializar os Obstaculos Randomicos "Prefabs"
    void InitiObstacle()
    {
        index = 0;

        for (int i = 0; i < obstacles.Length * 3; i++)
        {
            GameObject obj = Instantiate(obstacles[index], transform.position, Quaternion.identity);
            obstaclesToSpawn.Add(obj);
            obstaclesToSpawn[i].SetActive(false);
            index++;

            if (index == obstacles.Length)
            {
                index = 0;
            }
        }
    }

    IEnumerator SpawnRandomObstacles()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));

        int index = Random.Range(0, obstaclesToSpawn.Count);

        while (true)
        {
            if (!obstaclesToSpawn[index].activeInHierarchy)
            {
                obstaclesToSpawn[index].SetActive(true);
                obstaclesToSpawn[index].transform.position = transform.position;
                break;
            }
            else
            {
                index = Random.Range(0, obstaclesToSpawn.Count);
            }
        }

        StartCoroutine(SpawnRandomObstacles());
    }

}
