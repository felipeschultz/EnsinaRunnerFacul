using UnityEngine;

public class ObstacleMovement : EnsinaRunnerController
{
    public float moveObstacle = -3f;
    private Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(moveObstacle, 0);
    }
}