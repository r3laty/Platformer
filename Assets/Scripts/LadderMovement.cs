using UnityEngine;

public class LadderMovement : MonoBehaviour
{ 
    private float _vertical;
    private bool _isLadder;
    private bool _isClimbing;
    [SerializeField] private float climbingSpeed = 7;
    [SerializeField] private Rigidbody2D playerRb; 

    private void Update()
    {
        _vertical = Input.GetAxis("Vertical");

        if(_isLadder && Input.GetKeyDown(KeyCode.E))
        {
            _isClimbing = true;
        }
    }
    private void FixedUpdate() 
    {
        if(_isClimbing)
        {
            playerRb.gravityScale = 0;

            playerRb.velocity = new Vector2(0, _vertical * climbingSpeed);
            
        }
        else
        {
            playerRb.gravityScale = 1;          
        }   
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _isLadder = true;
        }   
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _isLadder = false;
            _isClimbing = false;
        }   
    }
}
