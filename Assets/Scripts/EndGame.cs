using System.Collections;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private BringKeyCard key;
    [SerializeField] private GameObject endGamePic;
    [SerializeField] private GameObject dieMenu;
    private bool isEndTrigger;

    private void Update()
    {
        if (isEndTrigger)
        {
            dieMenu.SetActive(false);
        }
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
