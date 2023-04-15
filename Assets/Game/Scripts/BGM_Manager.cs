using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Manager : MonoBehaviour
{
    [SerializeField]
    private AudioClip BGM;
    [SerializeField]
    private AudioClip Dead_BGM;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Slider BGMSlider;
    private void Awake()
    {
        BGMPlay();
    }
    private void Update()
    {
        audioSource.volume = BGMSlider.value;
    }
    public void BGMPlay()
    {
        audioSource.clip = BGM;
        audioSource.Play();
    }
    public void DeadBGMPlay()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(Dead_BGM);
    }
}
