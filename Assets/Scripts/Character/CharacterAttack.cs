using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public float damage = 10;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private Animator characterAnime;
    private float _rayCastDistance = 100f;
    private bool _isAttacking;

    private void Update()
    {
        _isAttacking = Input.GetButtonDown("Fire1");
        PunchAnimation();
    }
    private void DealDamage()
    {
        RaycastHit2D hit_right = Physics2D.Raycast(transform.position, Vector2.right, _rayCastDistance);
        RaycastHit2D hit_left = Physics2D.Raycast(transform.position, Vector2.left, _rayCastDistance);

        if (hit_right.collider != null && hit_right.collider.CompareTag("Enemy"))
        {
            hit_right.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        if (hit_left.collider != null && hit_left.collider.CompareTag("Enemy"))
        {
            hit_left.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
    private void PunchAnimation()
    {
        if (_isAttacking)
        {
            characterAnime.SetTrigger("Punch");
        }
    }
}
