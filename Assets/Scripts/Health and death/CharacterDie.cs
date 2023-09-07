using Cinemachine;
using UnityEngine;

public class CharacterDie : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCinemachine;
    [SerializeField] private GameObject dieMenu;
    [SerializeField] private Transform playerTransform;
    
    private CharacterController _characterController;
    private CharacterHealth _characterHealth;
    private CapsuleCollider2D _characterCollider;
    private SpriteRenderer _characterSpriteRenderer;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _characterHealth = GetComponent<CharacterHealth>();
        _characterCollider = GetComponent<CapsuleCollider2D>();
        _characterSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_characterHealth.maxHp <= 0 || playerTransform.position.y < -10)
        {
            Die();
        }
    }
    public void Die()
    {
        mainCinemachine.enabled = false;
        _characterController.enabled = false;
        _characterCollider.enabled = false;
        _characterSpriteRenderer.enabled = false;
        dieMenu.SetActive(true);
    }
}
