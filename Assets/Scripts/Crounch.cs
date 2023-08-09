using UnityEngine;

public class Crounch : MonoBehaviour
{   
    private Animator playerAnime;
    private CharacterJump jump;
    private CharacterMovement movement;
    private void Awake()     
    {
        movement = GetComponent<CharacterMovement>();
        jump = GetComponent<CharacterJump>();
        playerAnime = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && jump.isGround)
        {
            playerAnime.SetInteger("Crounch", 1);
        }
        else if(Input.GetKeyUp(KeyCode.C) || !jump.isGround)
        {
            playerAnime.SetInteger("Crounch", 0);
        }
    }
}
