using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{ 
    private Rigidbody2D playerRb;
    [HideInInspector] public bool isGround;
    bool wall;
    [SerializeField] private float _checkRadius;
    private void Start() 
    {
        playerRb = GetComponent<Rigidbody2D>();   
    }
    private void Update() 
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
    public void Jump(float jumpForce)
    {
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    // private void OnCollisionEnter2D(Collision2D other) 
    // {
    //     if(other.gameObject.CompareTag("Ground"))
    //     {
    //         isGround = true;
    //     }   
    // }
    // private void OnCollisionExit2D(Collision2D other) 
    // {
    //     if(other.gameObject.CompareTag("Ground"))
    //     {
    //         isGround = false;
    //     } 
    // }


}
