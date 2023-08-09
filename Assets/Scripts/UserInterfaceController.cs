using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] private Slider mainMenu_soundControlSlider;
    [SerializeField] private Slider pauseMenu_soundControlSlider;
    [SerializeField] private AudioSource mainAudio;
    private float _defaultMusicVolume = 0.5f;
    private void Start()
    {
        mainMenu_soundControlSlider.value = _defaultMusicVolume;
        mainAudio.volume = _defaultMusicVolume;
        Time.timeScale = 0;
    }
    public void StartButtonClick()
    {
        Time.timeScale = 1;
    }
    public void PauseButtonClick()
    {
        Time.timeScale = 0;
    }
    public void ContinueButtonClick()
    {
        Time.timeScale = 1;
    }
    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Update()
    {
        mainAudio.volume = mainMenu_soundControlSlider.value;
    }
}
