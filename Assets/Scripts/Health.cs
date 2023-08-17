using UnityEngine;

public class Health : MonoBehaviour
{
    private bool _isAlive;

    private void Start()
    {
        _isAlive = true;
    }
    public void TakeDamage(float currentHp, float damage)
    {
        currentHp = currentHp - damage;
        Debug.Log(currentHp + " HP");
        CheckIsAlive(currentHp);
    }
    private void CheckIsAlive(float currentrHp)
    {
        if(currentrHp < 0)
        {
            _isAlive = false;
        }
        if (!_isAlive)
        {
            Destroy(gameObject);    
        }
    }
}
