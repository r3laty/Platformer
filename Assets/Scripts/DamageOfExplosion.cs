using UnityEngine;

public class DamageOfExplosion : MonoBehaviour
{
    [SerializeField] private float maxDamage;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private CharacterHealth characterHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerOfExplosion"))
        {
            float distance = Vector2.Distance(transform.position, collision.transform.position);
            float damagePercentage = Mathf.Clamp01(1 - (distance / explosionRadius));
            float damage = maxDamage * damagePercentage;

            characterHealth.TakeDamage(damage);
        }
    }
}
