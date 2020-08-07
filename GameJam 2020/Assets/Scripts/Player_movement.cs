using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed = 1f;
    
    private float movement_X;
    private float movement_Y;
    private Vector2 movement;
    private bool facingRight = true;

    public Rigidbody2D rb;
    public Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement_X = Input.GetAxisRaw("Horizontal");
        movement_Y = 0;
        movement = new Vector2(movement_X, movement_Y);
        anim.SetFloat("speed", Mathf.Abs(movement_X));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        if(facingRight == false && movement_X > 0)
        {
            flip();
        }
        else if(facingRight == true && movement_X < 0)
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
    
}
