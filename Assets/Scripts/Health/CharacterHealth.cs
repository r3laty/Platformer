using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    private SpriteRenderer _characterSprite;
    private CharacterController _characterController;
    private BoxCollider2D _characterCollider;
    private GameObject _characterLayerMask;
    private bool _isAlive;

    public float maxHp;
    private void Awake()
    {
        _characterSprite = GetComponent<SpriteRenderer>();
        _characterController = GetComponent<CharacterController>();
        _characterCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        _isAlive = true;
    }
    public void TakeDamage(float damage)
    {
        maxHp = maxHp - damage;
        Debug.Log(maxHp + " character hp");
        CheckIsAlive();
    }
    private void CheckIsAlive()
    {
        if (maxHp <= 0)
        {
            _isAlive = false;
        }
        if (!_isAlive)
        {
            //Destroy(gameObject);
            gameObject.layer = 0;
            _characterSprite.enabled = false;
            _characterController.enabled = false;
            _characterCollider.enabled = false;
        }
    }
}
