using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private float currentHp = 10;
    private void Start()
    {
        maxHp = currentHp;
    }
    public override void TakeDamage(float damage)
    {
        Debug.Log("Enemy hp " + maxHp);
        base.TakeDamage(damage);
    }
}
