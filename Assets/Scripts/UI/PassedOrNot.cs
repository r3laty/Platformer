using UnityEngine;
using UnityEngine.SceneManagement;

public class PassedOrNot : UserInterfaceController
{
    [Header("Use in currrent script")]
    [SerializeField] private GameObject dontDestroyOnLoadObject;
    [SerializeField] private int mainMenuBuildIndex;
    public void YesButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void NoButton()
    {
        RestartButtonClick();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenuBuildIndex);
        dontDestroyOnLoadObject = GameObject.Find("Music");
        Destroy(dontDestroyOnLoadObject);
    }
}
