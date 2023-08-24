using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Slider musicController;
    private void Start()
    {
        musicController.value = musicSource.volume;
    }
    private void Update()
    {
        musicSource.volume = musicController.value;
    }
}   
