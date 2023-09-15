using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeJoke : MonoBehaviour
{
    [SerializeField] private GameObject jokeText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerOfJoke"))
        {
            jokeText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerOfJoke"))
        {
            jokeText.SetActive(false);
        }
    }
}
