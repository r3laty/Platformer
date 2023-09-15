using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] private GameObject characterGO;

    [HideInInspector] public bool isStarted;

    private Animator _characterAnime;
    private CharacterController _characterController;
    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = characterGO.GetComponent<Rigidbody2D>();
        _characterController = characterGO.GetComponent<CharacterController>();
        _characterAnime = characterGO.GetComponent<Animator>();
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
    public void FreezeTime()
    {
        isStarted = false;
        _characterController.enabled = false;
        _characterAnime.enabled = false;
    }
    public void UnfreezeTime()
    {
        isStarted = true;
        _characterController.enabled = true;
        _characterAnime.enabled = true;
    }
}
