using UnityEngine;

public class CharacterWallSlide : MonoBehaviour
{
    private CharacterController controller;
    private CharacterMovement movement;
    private Animator playerAnime;
    [HideInInspector] public bool wall;
    public float slideSpeed = 2;

    private void Awake() 
    {
        playerAnime = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        movement = GetComponent<CharacterMovement>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
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
            playerAnime.SetBool("wallSlide", false);


            movement.Move(controller.movingVec, controller.speed);
        }
    }
}
