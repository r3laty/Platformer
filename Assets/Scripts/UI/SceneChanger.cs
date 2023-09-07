using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private List<int> sceneIndex;
    public void lvlOne() => SceneManager.LoadScene(sceneIndex[0]);
    public void lvlTwo() => SceneManager.LoadScene(sceneIndex[1]);
    public void lvlThree() => SceneManager.LoadScene(sceneIndex[2]);
    public void lvlFour() => SceneManager.LoadScene(sceneIndex[3]);
    public void lvlFive() => SceneManager.LoadScene(sceneIndex[4]);

}
