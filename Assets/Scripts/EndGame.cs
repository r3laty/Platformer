using System.Collections;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private BringKeyCard key;
    [SerializeField] private GameObject endGamePic;
    [HideInInspector] public bool _theEnd;
    private bool _isEndTrigger;

    private void Update()
    {
        StartCoroutine(EndOfTheGame());
    }
    private IEnumerator EndOfTheGame()
    {
        if(key.key && _isEndTrigger)
        {
            _theEnd = true;
            yield return new WaitForSeconds(1);
            endGamePic.SetActive(true);
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
