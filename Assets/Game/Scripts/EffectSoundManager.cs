using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioclip;
    [SerializeField]
    private AudioSource POP;
    public void PopPlay()
    {
        POP.PlayOneShot(audioclip);
    }
}
