using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement_Medium : MonoBehaviour
{
    public float speed = 1f;
    public int Total_Jumps = 1;
    public float jumpForce = 1f;

    private float movement_X;
    private float movement_Y;
    private Vector2 movement;
    private bool facingRight = true;

    public Rigidbody2D rb;
    public Animator anim;

    private bool isGrounded;
    public Transform groundCheck;
    private float groundCheckRadius= 0.2f;
    public LayerMask whatIsGround;

    public int cur_jumps = 0;
    private bool launched;

    public GameObject Smoke;

    //public Sprite test;

    // Start is called before the first frame update
    void Start()
    {
        cur_jumps = Total_Jumps;
        //Smoke = GameObject.Find("Exhaust_Fume");
        Smoke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement_X = Input.GetAxisRaw("Horizontal");
        movement_Y = 0;
        movement = new Vector2(movement_X, movement_Y);
        anim.SetFloat("speed", Mathf.Abs(movement_X));

        if(rb.velocity.y == 0)
        {
            launched = false;
        }

        if (isGrounded == true && launched == false)
        {
            cur_jumps = Total_Jumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && cur_jumps > 0)
        {
            Jump();
            launched = true;
            cur_jumps--;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        rb.velocity = new Vector2(movement_X * speed, rb.velocity.y);
        if (facingRight == false && movement_X > 0)
        {
            flip();
        }
        else if (facingRight == true && movement_X < 0)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void Jump()
    {
        //smoke();
        Vector3 up = transform.TransformDirection(Vector3.up);
        float x = rb.velocity.x;
        //float y = rb.velocity.y;
        rb.velocity = new Vector2(x, 0f);
        rb.AddForce(up * jumpForce, ForceMode2D.Impulse);
        
    }

    
}
