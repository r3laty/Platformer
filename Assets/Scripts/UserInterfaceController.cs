using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] private Slider mainMenu_soundControlSlider;
    [SerializeField] private Slider pauseMenu_soundControlSlider;
    [SerializeField] private AudioSource mainAudio;
    [SerializeField] private GameObject characterGO;

    [HideInInspector] public bool isStarted;

    private Animator _characterAnime;
    private CharacterController _characterController;
    private Rigidbody2D _rigidbody;
    private float _defaultMusicVolume = 0.5f;
    private void Awake()
    {
        _rigidbody = characterGO.GetComponent<Rigidbody2D>();
        _characterController = characterGO.GetComponent<CharacterController>();
        _characterAnime = characterGO.GetComponent<Animator>();
    }
    private void Start()
    {
        mainMenu_soundControlSlider.value = _defaultMusicVolume;
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
    private void Update()
    {
        mainAudio.volume = mainMenu_soundControlSlider.value;
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
