using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator _playerAnime;
    private Rigidbody2D _playerRb;
    private CharacterJump _jump;
    private CharacterWallSlide _wallSlide;
    private CharacterMovement _movement;

    private bool _isButtonDown;
    private bool _doubleJump;
    private bool _walljump;

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
        _isButtonDown = Input.GetButtonDown("Jump");

        _movement.Flip();

        _movement.RunAnimation();


        if (_isButtonDown)
        {
            _playerAnime.SetBool("jump", true);
            if (_jump.isGround)
            {
                _jump.Jump(jumpForce);
                _doubleJump = true;
            }
            else if (_doubleJump)
            {
                _jump.Jump(jumpForce);
                _doubleJump = false;
            }
        }
        else
        {
            _playerAnime.SetBool("jump", false);
        }


        //if (_isButtonDown && _wallSlide.wall)
        //{
        //    _walljump = true;
        //}
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        movingVec = new Vector2(horizontal, transform.position.y);

        _movement.Move(movingVec, speed);

        if (_walljump)
        {
            _playerRb.velocity = new Vector2(0, Vector2.up.y * walljumpForce);
            _wallSlide.wall = false;
            _walljump = false;
        }
    }
}
