using UnityEngine;
using UnityEngine.UI;

public class CharacterHpBar : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private Text hpBarText;
    private CharacterHealth _characterHealth;
    private Animator _playerAnime;
    private void Awake()
    {
        _characterHealth = GetComponent<CharacterHealth>();
        _playerAnime = GetComponent<Animator>();
    }
    
    private void Start()
    {
        hpBarText.text = _characterHealth.maxHp.ToString();
        hpBar.value = _characterHealth.maxHp;
    }
    private void Update()
    {
        hpBarText.text = _characterHealth.maxHp.ToString();
        hpBar.value = _characterHealth.maxHp;
    }
}
