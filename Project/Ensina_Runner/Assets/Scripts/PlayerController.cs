using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce;

    private Rigidbody2D MyRigidbody;

    public bool Grounded;
    public LayerMask WhatIsGround;

    private Collider2D MyCollider;

    private Animator MyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();

        MyCollider = GetComponent<Collider2D>();

        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = Physics2D.IsTouchingLayers(MyCollider, WhatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Grounded)
            {
                MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x, JumpForce);
            }
        }

        MyAnimator.SetBool("Grounded", Grounded);
    }
}