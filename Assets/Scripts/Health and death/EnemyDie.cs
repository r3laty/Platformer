using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    private EnemyAttack _enemyController;
    private EnemyHealth _enemyHealth;
    private Collider2D _enemyCollider;
    private SpriteRenderer _enemySpriteRenderer;
    private void Awake()
    {
        _enemyController = GetComponent<EnemyAttack>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyCollider = GetComponent<Collider2D>();
        _enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (_enemyHealth.maxHp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        _enemyController.enabled = false;
        _enemyCollider.enabled = false;
        _enemySpriteRenderer.enabled = false;
    }
}
