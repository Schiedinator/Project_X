using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove: MonoBehaviour

{

    

    public float Speed = 5;

public float jumpForce = 10;

public SpriteRenderer sr;

public Transform groundCheck;

public LayerMask whatisGround;

public float checkRadius;



public int extraJumps;

private float move;

private bool isGrounded;

private Rigidbody2D rb;



void Start()

{

    rb = GetComponent<Rigidbody2D>();

}



void Update()

{

    jumpPlayer();

}

void FixedUpdate()

{

    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);

    // for stop endless jumping I use this code

    move = Input.GetAxis("Horizontal");

    rb.velocity = new Vector2(move * Speed, rb.velocity.y);

    //code for moving Horizontal

    flipPlayer();

}

void flipPlayer()

{

    if (move > 0)

    {

        sr.flipX = false;

    }

    else if (move < 0)

    {

        sr.flipX = true;

    }

    //code for sprite to flipX, so u dont need to make a 'Left' and 'Right' Sprite but 'Side'Sprite

}



void jumpPlayer()

{

    if (isGrounded == true)

    {

        extraJumps = 0;

    }



    if (Input.GetButtonDown("Jump") && extraJumps > 0)

    {

        rb.velocity = Vector2.up * jumpForce;

        extraJumps--;

        //if u jump and can jump in a mount of extrajumpcount,

    }

    else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)

    {

        rb.velocity = Vector2.up * jumpForce;

        //while u jumping like a maniac but extrajumpcount set into 0? u will fall and u cant jump no more until u stand on the objective which is tagged 'Ground'

    }

}

}

