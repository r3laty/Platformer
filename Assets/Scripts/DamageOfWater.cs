using System.Collections;
using System.Threading;
using UnityEngine;

public class DamageOfWater : MonoBehaviour
{
    [SerializeField] private float damage = 1;
    private CharacterHealth _characterHealth;
    private bool _drowned;
    private Coroutine _damageDealCoroutine;
    private void Awake()
    {
        _characterHealth = GetComponent<CharacterHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            _drowned = true;
            _damageDealCoroutine = StartCoroutine(DealDamage());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            if (_damageDealCoroutine != null)
            {
                _drowned = false;
                StopCoroutine(_damageDealCoroutine);
                _damageDealCoroutine = null;
            }
        }
    }
    private IEnumerator DealDamage()
    {
        while (_drowned)
        {
            _characterHealth.maxHp = _characterHealth.maxHp - damage;
            yield return new WaitForSeconds(2);
        }
    }
}
