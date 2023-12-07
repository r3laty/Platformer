using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private List<int> sceneIndex;
    public void LvlOne() => SceneManager.LoadScene(sceneIndex[0]);
    public void LvlTwo() => SceneManager.LoadScene(sceneIndex[1]);
    public void LvlThree() => SceneManager.LoadScene(sceneIndex[2]);
    public void LvlFour() => SceneManager.LoadScene(sceneIndex[3]);
    public void LvlFive() => SceneManager.LoadScene(sceneIndex[4]);
    public void LeaveButton() => Application.Quit();

}
