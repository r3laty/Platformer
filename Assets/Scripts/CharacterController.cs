using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private CharacterMovement movement;
    private bool run;
    private bool walk;
    [HideInInspector] public float horizontal;
    [HideInInspector] public float _speed = 5;

    private void Start() 
    {
        movement = GetComponent<CharacterMovement>(); 
    }
    private void Update() 
    {
        movement.RunAnimation();
        movement.WalkAnimation();
    }
    private void FixedUpdate() 
    {
        horizontal = Input.GetAxis("Horizontal");  
        Vector2 moovingVector = new Vector2(horizontal, transform.position.y);

        movement.Move(moovingVector, _speed);

        movement.Flip();
    }
}
