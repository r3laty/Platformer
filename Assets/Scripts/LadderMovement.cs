using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{ 
    private float vertical;
    private bool isLadder;
    private bool isClimbing;
    private CharacterMovement movement;
    private CharacterController controller;
    [SerializeField] private float _climbingSpeed = 7;
    [SerializeField] private Rigidbody2D playerRb; 

    private void Awake() 
    {
        movement = GetComponent<CharacterMovement>();   
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Input.GetKeyDown(KeyCode.E))
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate() 
    {
        if(isClimbing)
        {
            playerRb.gravityScale = 0;

            playerRb.velocity = new Vector2(0, vertical * _climbingSpeed);
            
        }
        else
        {
            playerRb.gravityScale = 1;          
        }   
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ladder"))
        {
            isLadder = true;
        }   
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }   
    }
}
