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

    private void Update()
    {
        audioSource.volume = EffectSoundSlider.value;
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
