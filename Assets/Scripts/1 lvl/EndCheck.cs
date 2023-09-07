using UnityEngine;

public class EndCheck : MonoBehaviour
{
    [SerializeField] private GameObject passMenu;
    [SerializeField] private PassedOrNot passed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            passMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
