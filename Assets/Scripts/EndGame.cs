using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private BringKeyCard key;
    [SerializeField] private GameObject endGamePic;
    private bool isEndTrigger;

    private void Update()
    {
        StartCoroutine(EndOfTheGame());
    }
    private IEnumerator EndOfTheGame()
    {
        if(key.key && isEndTrigger)
        {
            yield return new WaitForSeconds(1);
            endGamePic.SetActive(true);
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndGame"))
        {
            isEndTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EndGame"))
        {
            isEndTrigger = false;
        }
    }
}
