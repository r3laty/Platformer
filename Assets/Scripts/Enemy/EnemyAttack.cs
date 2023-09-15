using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 2;
    [SerializeField] private float range;
    [SerializeField] private float raycastDistance;
    [SerializeField] private CharacterHealth characterHealth;
    [SerializeField] private LayerMask playerLayerMask;
    private float _coolDownTime = 1.3f;
    private bool _canAttack = true;
    private Animator _enemyAnime;
    private void Awake()
    {
        _enemyAnime = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_canAttack && PlayerInSight())
        {
            StartCoroutine(AttackCoolDown());
            StartCoroutine(Attack());
        }
    }
    private IEnumerator AttackCoolDown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_coolDownTime);
        _canAttack = true;
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit_right = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, playerLayerMask);
        RaycastHit2D hit_left = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, playerLayerMask);
        return hit_right.collider != null || hit_left.collider != null;
    }
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(_coolDownTime);
        _enemyAnime.SetTrigger("Attack");
        characterHealth.TakeDamage(damage);
    }
}
