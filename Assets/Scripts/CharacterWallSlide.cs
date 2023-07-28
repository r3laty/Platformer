using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWallSlide : MonoBehaviour
{
    [SerializeField] private float _checkRadius = 1;
    private Rigidbody2D playerRb;
    private CharacterJump jump;
    private CharacterController controller;
    private CharacterMovement movement;
    [HideInInspector] public bool wall;
    public float slideSpeed = 2;

    private void Start() 
    {
        playerRb = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController>(); 
        jump = GetComponent<CharacterJump>();
    }
    private void Update() 
    {
        // Physics2D.queriesStartInColliders = false;
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, _checkRadius);

        // if(!jump.isGround && hit.collider != null)
        // {
        //     //Debug.Log("Hit");
        //     playerRb.velocity = new Vector2(0, slideSpeed);
        //     controller.jumpAttempts = 3;
        // }
    }
    // private void FixedUpdate() 
    // {
    //     if(wall)
    //     {
    //         Debug.Log("worked");
    //         Vector2 wallSlide = new Vector2(0, slideSpeed); 
    //         movement.Move(wallSlide, slideSpeed);
    //     }
    // } 
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Wall"))
        {
            wall = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("Wall"))
        {
            wall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Wall"))
        {
            wall = false;
        }
    }
}
