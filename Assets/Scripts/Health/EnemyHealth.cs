using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHp;
    private float _currentHp;
    private bool _isAlive;
    private void Start()
    {
        _isAlive = true;
        _currentHp = maxHp;
    }
    public void TakeDamage(float damage)
    {
        _currentHp = _currentHp - damage;
        CheckIsAlive();
    }
    private void CheckIsAlive()
    {
        if (_currentHp <= 0)
        {
            _isAlive = false;
        }
        if (!_isAlive)
        {
            _currentHp = maxHp;
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());

        }
    }

}
