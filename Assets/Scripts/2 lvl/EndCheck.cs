using UnityEngine;
using UnityEngine.Serialization;

public class EndCheck : MonoBehaviour
{
    [SerializeField] [FormerlySerializedAs("passMenu")] private GameObject winMenu;
    [HideInInspector] public bool gameCompleted;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameCompleted = true;
            Debug.Log("Game completed");
        }
    }
}
