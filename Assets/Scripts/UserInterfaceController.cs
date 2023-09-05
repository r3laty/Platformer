using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] private GameObject characterGO;
    [SerializeField] private GameObject dieMenu;

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
    private void FreezeTime()
    {
        isStarted = false;
        //_rigidbody.velocity = Vector2.zero;
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
