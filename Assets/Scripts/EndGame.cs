using System.Collections;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject dieMenu;
    [SerializeField] private BringKeyCard key;
    [SerializeField] private GameObject passedSuccessfully;
    [SerializeField] private GameObject passedUnsussefully;    
    private bool _isEndTrigger;

    private void Update()
    {
        StartCoroutine(EndOfTheGame());
    }
    private IEnumerator EndOfTheGame()
    {
        if(key.key && _isEndTrigger)
        {
            yield return new WaitForSeconds(1);
            passedSuccessfully.SetActive(true);
        }
        else if(!key.key && _isEndTrigger)
        {
            yield return new WaitForSeconds(1);
            passedUnsussefully.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndGame"))
        {
            _isEndTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EndGame"))
        {
            _isEndTrigger = false;
        }
    }
}
