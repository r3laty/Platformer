using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] private GameObject characterGO;
    [SerializeField] private GameObject dieMenu;

    [HideInInspector] public bool isStarted;

    private Animator _characterAnime;
    private CharacterController _characterController;
    private Rigidbody2D _rigidbody;
    private CharacterHealth _characterHealth;
    private EndGame _endGame;
    private void Awake()
    {
        _endGame = characterGO.GetComponent<EndGame>();
        _rigidbody = characterGO.GetComponent<Rigidbody2D>();
        _characterController = characterGO.GetComponent<CharacterController>();
        _characterAnime = characterGO.GetComponent<Animator>();
        _characterHealth = characterGO.GetComponent <CharacterHealth>();
    }
    //private void Start()
    //{
    //    FreezeTime();
    //}
    public void StartButtonClick()
    {
        UnfreezeTime();
    }
    public void PauseButtonClick()
    {
        FreezeTime();
    }
    public void ContinueButtonClick()
    {
        UnfreezeTime();
    }
    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Die()
    {
        if(_characterHealth.maxHp <= 0 || characterGO.transform.position.y < -10 && !_endGame._theEnd)
        {
            dieMenu.SetActive(true);
            Destroy(characterGO);
        }
    }
    private void Update()
    {
        Die(); 
    }
    private void FreezeTime()
    {
        isStarted = false;
        _rigidbody.velocity = Vector2.zero;
        _characterController.enabled = false;
        _characterAnime.enabled = false;
    }
    private void UnfreezeTime()
    {
        isStarted = true;
        _characterController.enabled = true;
        _characterAnime.enabled = true;
    }
}
