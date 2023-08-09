using UnityEngine;
//This script is input manager. He is in charge for input from user.
public class CharacterController : MonoBehaviour
{
    private Animator _playerAnime;
    private Rigidbody2D _playerRb;
    private CharacterJump _jump;
    private CharacterWallSlide _wallSlide;
    private CharacterMovement _movement;
    private bool isJumped;
    private bool isExtraJumped;
    private bool allow;
    private bool walljump;
    private bool learnMore;
    [SerializeField] private float walljumpForce = 5;
    [SerializeField] private float jumpForce = 5;
    [HideInInspector] public float horizontal;
    [HideInInspector] public float speed = 5;
    [HideInInspector] public Vector2 movingVec;

    private void Awake() 
    {
        _playerAnime = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody2D>();
        _jump = GetComponent<CharacterJump>();
        _wallSlide = GetComponent<CharacterWallSlide>();
        _movement = GetComponent<CharacterMovement>(); 
    }
    private void Update() 
    {
        _movement.RunAnimation();
        
        //_jump
        if (Input.GetKeyDown(KeyCode.Space) && _jump.isGround)
        {
            _playerAnime.SetBool("jump", true);
            isJumped = true;
            allow = true;
        }
        //double _jump
        else if(allow && Input.GetKeyDown(KeyCode.Space))
        {
            _playerAnime.SetBool("doubleJump", true);
            isExtraJumped = true;
            allow = false;
        }
        //wall _jump
        else if(Input.GetKeyDown(KeyCode.Space) && _wallSlide.wall)
        {
            walljump = true;
        }
    }
    private void FixedUpdate() 
    {
        horizontal = Input.GetAxis("Horizontal");  
        movingVec = new Vector2(horizontal, transform.position.y);

        _movement.Move(movingVec, speed);

        _movement.Flip();

        if(isJumped)
        {
            _jump.Jump(jumpForce);
            isJumped = false;
            _playerAnime.SetBool("jump", false);
        }
        else if(isExtraJumped)
        {
            _jump.Jump(jumpForce);
            isExtraJumped = false;
            _playerAnime.SetBool("doubleJump", false);   
        }
        else if(walljump)
        {
            _playerRb.velocity = new Vector2(0, Vector2.up.y * walljumpForce);
            _wallSlide.wall = false;
            walljump = false;
        }
    }
}
