using UnityEngine;

public class CharacterJump : MonoBehaviour
{ 
    private Rigidbody2D _playerRb;
    private Animator _jumpAnimation;
    [HideInInspector] public bool isGround;
    [SerializeField] private float checkRadius;

    private void Awake() 
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _jumpAnimation = GetComponent<Animator>();
    }
    private void Update() 
    {
        isGroundCheck();
    }
    
    public void Jump(float jumpForce)
    {
        _playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void isGroundCheck()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale, checkRadius);
        
        if(hit.collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}
