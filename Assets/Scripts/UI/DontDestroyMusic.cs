using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    private DontDestroyMusic _mInstance;
    private void Start()
    {
        if (_mInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _mInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
