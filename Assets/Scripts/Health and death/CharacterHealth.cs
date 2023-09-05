using UnityEngine;

public class CharacterHealth : Health
{
    [SerializeField] private float currentHp = 20;
    private void Start()
    {
        maxHp = currentHp;
    }
}
