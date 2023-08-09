using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    bool isLever;
    [HideInInspector] public bool toggleSwitch;
    [SerializeField] private Animator leverAnimator;

    private void Update() 
    {
        if(isLever && Input.GetKeyDown(KeyCode.E))
        {
            leverAnimator.SetBool("LeverOn", true);
            toggleSwitch = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Lever"))
        {
            isLever = true;
        }   
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Lever"))
        { 
            isLever = false;
        }     
    }
}
