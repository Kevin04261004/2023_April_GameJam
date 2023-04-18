using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip pop_Audio;
    [SerializeField]
    private AudioClip ClickButtonpop_Audio;
    [SerializeField]
    private Slider EffectSoundSlider;

    private void Awake()
    {
        EffectSoundSlider.value = DontDestroyManager.instance.tempEffectSound;
    }

    private void Update()
    {
        DontDestroyManager.instance.tempEffectSound = EffectSoundSlider.value;
        audioSource.volume = DontDestroyManager.instance.tempEffectSound;
    }
    public void PopPlay()
    {
        audioSource.PlayOneShot(pop_Audio);
    }

    public void ClickButtonPoP()
    {
        audioSource.PlayOneShot(ClickButtonpop_Audio);
    }
}
