using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector] public float maxHp = 0;
    public virtual void TakeDamage(float damage)
    {
        maxHp = maxHp - damage;
    }
}
