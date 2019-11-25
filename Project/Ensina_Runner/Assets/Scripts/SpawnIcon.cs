using UnityEngine;

public class SpawnIcon : EnsinaRunnerController
{
    // Start is called before the first frame update
    void Start()
    {
        Transform spawnMinIcon = GameObject.FindObjectOfType<GameController>().spawnMin;
        Transform spawnMaxIcon = GameObject.FindObjectOfType<GameController>().spawnMax;

        var spawnX = Random.Range(spawnMinIcon.position.x, spawnMaxIcon.position.x);
        var spawnY = Random.Range(spawnMinIcon.position.y, spawnMaxIcon.position.y);

        transform.position = new Vector3(spawnX, spawnY, 1);
    }
}