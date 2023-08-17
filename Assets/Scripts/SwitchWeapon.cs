using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private Animator _characterAnime;
    private void Awake()
    {
        _characterAnime = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Get key down");
            _characterAnime.Play("IdleWithSwordAnimation");
        }
    }
}
