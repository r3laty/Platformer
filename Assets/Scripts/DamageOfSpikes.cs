using UnityEngine;

public class DamageOfSpikes : MonoBehaviour
{
    [SerializeField] private CharacterDie die;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            die.Die();
        }
    }
}
