using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private CharacterController controller;
    private Animator characterAnime;

    private void Start() 
    {
        playerRb = GetComponent<Rigidbody2D>();
        characterAnime = GetComponent<Animator>();
        controller = GetComponent<CharacterController>(); 
    }

    public void Move(Vector2 moovingVector, float speed)
    {
        playerRb.velocity = new Vector2(moovingVector.x * speed, playerRb.velocity.y);
    }
    public void Flip()
    {
        if(controller.horizontal > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if(controller.horizontal < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
    }

    public void WalkAnimation()
    {
        if(controller.horizontal > 0)
        {
            characterAnime.SetBool("walk", true);
        }
        if(controller.horizontal < 0)
        {
            characterAnime.SetBool("walk", true);
        }
        if(controller.horizontal == 0 || Input.GetKeyUp(KeyCode.LeftShift))
        {
            characterAnime.SetBool("walk", false);
            characterAnime.SetBool("run", false);
        } 
    }
    public void RunAnimation()
    {
        if(controller.horizontal > 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            characterAnime.SetBool("walk", false);
            characterAnime.SetBool("run", true);
            controller.speed = 10;
        }

        if(controller.horizontal < 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            characterAnime.SetBool("walk", false);
            characterAnime.SetBool("run", true);
            controller.speed = 10;
        }
        if(controller.horizontal == 0 || Input.GetKeyUp(KeyCode.LeftShift))
        {
            characterAnime.SetBool("walk", false);
            characterAnime.SetBool("run", false);
            controller.speed = 5;
        }

    }
}
