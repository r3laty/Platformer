using UnityEngine;

public class CharacterWallSlide : MonoBehaviour
{
    private CharacterController _controller;
    private CharacterMovement _movement;
    private Animator _playerAnime;
    [HideInInspector] public bool wall;
    public float slideSpeed = 2;

    private void Awake() 
    {
        _playerAnime = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _movement = GetComponent<CharacterMovement>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Wall"))
        {
            wall = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wall = false;
            _playerAnime.SetBool("wallSlide", false);

            _movement.Move(_controller.movingVec, _controller.speed);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Wall"))
        {
            wall = false;
            _playerAnime.SetBool("wallSlide", false);


            _movement.Move(_controller.movingVec, _controller.speed);
        }
    }
}
