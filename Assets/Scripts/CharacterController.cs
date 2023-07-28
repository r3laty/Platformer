using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private CharacterJump jump;
    private CharacterWallSlide wallSlide;
    private CharacterMovement movement;
    private bool isJumped;
    private bool isExtraJumped;
    private bool allow;
    private bool wallJump;
    [SerializeField] private float _jumpForce = 5;
    [HideInInspector] public float horizontal;
    [HideInInspector] public float speed = 5;

    private void Start() 
    {
        playerRb = GetComponent<Rigidbody2D>();
        jump = GetComponent<CharacterJump>();
        wallSlide = GetComponent<CharacterWallSlide>();
        movement = GetComponent<CharacterMovement>(); 
    }
    private void Update() 
    {
        movement.RunAnimation();
        movement.WalkAnimation();
        if (Input.GetKeyDown(KeyCode.Space) && jump.isGround)
        {
            isJumped = true;
            allow = true;
        }
        else if(allow && Input.GetKeyDown(KeyCode.Space))
        {
            isExtraJumped = true;
            allow = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && wallSlide.wall)
        {
            wallJump = true;
        }

        // else if(Input.GetKeyDown(KeyCode.Space) && wallSlide.wallJump)
        // {
        //     Debug.Log("Wall jump");
        //     if(transform.localScale.x == 1.5f)
        //     {
        //         transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        //         wallJump = true;
        //     }
        //     else if (transform.localScale.y == -1.5f)
        //     {
        //         transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        //         wallJump = true;
        //     }
        // }
    }
    private void FixedUpdate() 
    {
        horizontal = Input.GetAxis("Horizontal");  
        Vector2 moovingVector = new Vector2(horizontal, transform.position.y);

        movement.Move(moovingVector, speed);

        movement.Flip();

        if(isJumped)
        {
            jump.Jump(_jumpForce);
            isJumped = false;
        }
        if(isExtraJumped)
        {
            jump.Jump(_jumpForce);
            isExtraJumped = false;
        }
        else if(wallJump)
        {
            playerRb.velocity = new Vector2(moovingVector.x * speed, wallSlide.slideSpeed);
            if(transform.localScale.x == 1.5f)
            {
                transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
                playerRb.velocity = new Vector2(playerRb.velocity.x, _jumpForce);
            }
            else if(transform.localScale.x == -1.5f)
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                playerRb.velocity = new Vector2(playerRb.velocity.x, _jumpForce);
                Debug.Log("Flip on +");
            }
            Debug.Log("Walljumped");
            wallJump = false;
        }
    }
    // private void DoubleJump()
    // {
    //     jump.Jump(_jumpForce);
    // }
}
