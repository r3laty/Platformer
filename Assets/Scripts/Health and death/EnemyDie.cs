using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    private EnemyAttack _enemyController;
    private EnemyHealth _enemyHealth;
    private Collider2D _enemyCollider;
    private SpriteRenderer _enemySpriteRenderer;
    [HideInInspector] public bool hasDied;
    public static int killedEnemiesCount { get; private set; } = 0;
    
    private void Awake()
    {
        _enemyController = GetComponent<EnemyAttack>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyCollider = GetComponent<Collider2D>();
        _enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        killedEnemiesCount = 0;
    }
    private void Update()
    {
        if (_enemyHealth.maxHp <= 0 && !hasDied)
        {
            Debug.Log("Âûחûגאועסÿ לועמה Die");
            Die();
            hasDied = true;
        }
    }
    private void Die()
    {
        killedEnemiesCount = killedEnemiesCount + 1;
        Debug.Log(killedEnemiesCount + " killed enemies count");
        
        _enemyController.enabled = false;
        _enemyCollider.enabled = false;
        _enemySpriteRenderer.enabled = false;
    }
}
