using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private GameObject aboutItemMenu;
    [SerializeField] private BringKeyCard keyCardScript;
    [SerializeField] private TextMeshProUGUI raisedText;
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

        //raising text activate
        if(keyCardScript.pickedUp)
        {
            StartCoroutine(RaisingTextActivating());
            learnMore = true;
        }

        //about item menu
        if (learnMore && Input.GetKeyDown(KeyCode.Tab))
        {
            aboutItemMenu.SetActive(true);
        }
        else if (learnMore && Input.GetKeyUp(KeyCode.Tab))
        {
            aboutItemMenu.SetActive(false);
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
    private IEnumerator RaisingTextActivating()
    {
        raisedText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);
        Vector3 newPosition = new Vector3(-221.9f, -129.7f, 0);
        Vector2 newScale = new Vector2(209.9684f, 30.1511f);
        
        raisedText.text = "ключ карта";
        raisedText.fontSize = 24;
        raisedText.transform.localPosition = newPosition;
        raisedText.rectTransform.sizeDelta = newScale;
    }
}
