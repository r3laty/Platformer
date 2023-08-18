using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] private Slider soundControlSlider;
    [SerializeField] private AudioSource mainAudio;
    [SerializeField] private GameObject characterGO;
    [SerializeField] private GameObject dieMenu;

    [HideInInspector] public bool isStarted;

    private Animator _characterAnime;
    private CharacterController _characterController;
    private Rigidbody2D _rigidbody;
    private CharacterHealth _characterHealth;
    private float _defaultMusicVolume = 0.5f;
    private void Awake()
    {
        _rigidbody = characterGO.GetComponent<Rigidbody2D>();
        _characterController = characterGO.GetComponent<CharacterController>();
        _characterAnime = characterGO.GetComponent<Animator>();
        _characterHealth = characterGO.GetComponent <CharacterHealth>();
    }
    private void Start()
    {
        soundControlSlider.value = _defaultMusicVolume;
        mainAudio.volume = _defaultMusicVolume;
        FreezeTime();
    }
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
        if(_characterHealth.maxHp <= 0 || characterGO.transform.position.y < -10)
        {
            dieMenu.SetActive(true);
            Destroy(characterGO);
        }
    }
    private void Update()
    {
        Die(); 
        mainAudio.volume = soundControlSlider.value;
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
