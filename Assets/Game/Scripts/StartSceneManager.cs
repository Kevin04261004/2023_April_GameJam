using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    private void Awake()
    {
#if UNITY_STANDALONE_WIN
        Screen.SetResolution(1080, 1920, false);
#elif UNITY_ANDROID
        Screen.SetResolution(1080, 1920, false);
#endif
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
