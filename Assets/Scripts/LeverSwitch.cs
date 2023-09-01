using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    bool _isCharacter;
    [HideInInspector] public bool toggleSwitch;
    [SerializeField] private Animator leverAnimator;

    private void Update() 
    {
        if(_isCharacter && Input.GetKeyDown(KeyCode.E))
        {
            leverAnimator.SetBool("LeverOn", true);
            toggleSwitch = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _isCharacter = true;
        }   
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        { 
            _isCharacter = false;
        }     
    }
}
