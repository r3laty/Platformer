using UnityEngine;

public class CharacterJump : MonoBehaviour
{ 
    private Rigidbody2D playerRb;
    [HideInInspector] public bool isGround;
    [SerializeField] private float _checkRadius;
    private Animator playerAnime;
    private void Awake() 
    {
        playerAnime = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();   
    }
    private void Update() 
    {
        isGroundCheck();
    } 
    public void Jump(float jumpForce)
    {
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void isGroundCheck()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale, _checkRadius);
        
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
