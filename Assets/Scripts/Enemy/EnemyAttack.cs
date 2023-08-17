using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 2;
    private float _cooldownTimer = Mathf.Infinity;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float raycastDistance;
    [SerializeField] private CharacterHealth characterHealth;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private BoxCollider2D collider;
    private Animator _enemyAnime;
    private void Awake()
    {
        _enemyAnime = GetComponent<Animator>();
    }
    private void Update()
    {
        _cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (_cooldownTimer >= attackCooldown)
            {
                _cooldownTimer = 0;
                _enemyAnime.SetTrigger("Attack");
                characterHealth.TakeDamage(damage);
            }
        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit_right = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, playerLayerMask);
        RaycastHit2D hit_left = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, playerLayerMask);
        return hit_right.collider != null || hit_left.collider != null;
    }
}
