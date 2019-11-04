using UnityEngine;

public class PlayerController : EnsinaRunnerController
{
    public float jumpForce;
    private Rigidbody2D myRigidbody;
    public bool grounded;
    public LayerMask whatIsGround;
    private Collider2D myCollider;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

        myAnimator.SetBool("Grounded", grounded);
    }
}