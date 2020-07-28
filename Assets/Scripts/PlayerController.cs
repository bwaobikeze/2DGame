using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator myAnim;
    Rigidbody2D body;
    public float PlayerSpeed;
    bool frontDirection;
    //jumping variables 
    float groundCheckRadius = 0.2f;
    bool grounded = false;
    public LayerMask groundlayer;
    public Transform groundCheck;
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        frontDirection = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if grounded 
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundlayer);
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("verticalSpeed", body.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("Speed", Mathf.Abs(move));

        body.velocity = new Vector2(move * PlayerSpeed, body.velocity.y);
        if (move > 0 && !frontDirection)
        {
            flip();

        }
        else if (move < 0 && frontDirection)
            flip();



    }
    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            body.AddForce(new Vector2(0, jumpHeight));

        }

    }
    void flip()
    {
        frontDirection = !frontDirection;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }
}
