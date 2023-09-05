using UnityEngine;
using UnityEngine.UI;

public class CharacterHpBar : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private Text hpBarText;
    private CharacterHealth _characterHealth;
    private void Awake()
    {
        _characterHealth = GetComponent<CharacterHealth>();
    }
    
    private void Start()
    {
        hpBarText.text = _characterHealth.maxHp.ToString("F0");
        hpBar.value = _characterHealth.maxHp;
    }
    private void Update()
    {
        hpBarText.text = _characterHealth.maxHp.ToString("F0");
        hpBar.value = _characterHealth.maxHp;
    }
}
