using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator characterAnime;
    private CharacterController controller;

    private void Start() 
    {
        controller = GetComponent<CharacterController>();
        characterAnime = GetComponent<Animator>();
    }
    private void FixedUpdate() 
    {
        RunAnimation();
    }
    private void WalkAnimation()
    {
        if(controller.horizontal == 0);
    }
    private void RunAnimation()
    {
        if(controller.horizontal > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            characterAnime.SetBool("run", true);
        }
        else if(controller.horizontal < 0 && Input.GetKey(KeyCode.LeftShift))
        {
            characterAnime.SetBool("run", true);
        }
        else if(controller.horizontal == 0)
        {
            characterAnime.SetBool("run", false);
        }
    }
}
