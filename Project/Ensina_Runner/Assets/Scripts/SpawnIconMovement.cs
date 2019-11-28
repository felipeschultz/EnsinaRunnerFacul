using UnityEngine;

public class SpawnIconMovement : EnsinaRunnerController
{
    public float velocitySpawnIcon;
    private Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(velocitySpawnIcon, 0);
    }
}