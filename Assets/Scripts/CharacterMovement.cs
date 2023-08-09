using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private CharacterController controller;
    private CharacterWallSlide  wallSlide;
    private Animator characterAnime;
    private AnimatorControllerParameter[] animator_parametres;

    private void Awake() 
    {
        playerRb = GetComponent<Rigidbody2D>();
        characterAnime = GetComponent<Animator>();
        animator_parametres = characterAnime.parameters;
        controller = GetComponent<CharacterController>(); 
        wallSlide = GetComponent<CharacterWallSlide>();
    }

    public void Move(Vector2 movingVector, float speed)
    {
        playerRb.velocity = new Vector2(movingVector.x * speed, playerRb.velocity.y);
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

    public void RunAnimation()
    {
        if(controller.horizontal > 0.01f && !wallSlide.wall)
        {
            characterAnime.SetBool("run", true);
            controller.speed = 8;
        }

        if(controller.horizontal < -0.01f && !wallSlide.wall)
        {
            characterAnime.SetBool("run", true);
            controller.speed = 8;
        }
        if(controller.horizontal == 0)
        {
            foreach(AnimatorControllerParameter parameter in animator_parametres)   //Disable animations
            {
                if(parameter.type == AnimatorControllerParameterType.Bool)
                {
                    characterAnime.SetBool(parameter.name, false);
                }
            }

            controller.speed = 8;
        }
    }
}
