using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWallSlide : MonoBehaviour
{
    [SerializeField] private float _checkRadius = 1;
    private bool attractionTrigger = false;
    private Rigidbody2D playerRb;
    private CharacterJump jump;
    private CharacterController controller;
    private CharacterMovement movement;
    private Animator playerAnime;
    [HideInInspector] public bool wall;
    public float slideSpeed = 2;

    private void Awake() 
    {
        playerAnime = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController>();
        movement = GetComponent<CharacterMovement>(); 
        jump = GetComponent<CharacterJump>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Wall"))
        {
            wall = true;
        }
    }
    // private void OnTriggerStay2D(Collider2D other) 
    // {
    //     if(other.CompareTag("Wall"))
    //     {
    //         wall = true;
    //         playerAnime.SetBool("wallSlide", true);
    //         playerAnime.SetBool("run", false);

    //         Debug.Log(wall + " wall ontriggerstay");
            
    //         playerRb.velocity = new Vector2(controller.movingVec.x * controller.speed, slideSpeed);
    //     }
    // }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Wall"))
        {
            wall = false;
            playerAnime.SetBool("wallSlide", false);

            Debug.Log(wall + " wall ontriggerexit");

            movement.Move(controller.movingVec, controller.speed);
        }
    }
}
