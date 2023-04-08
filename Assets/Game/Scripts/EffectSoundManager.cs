using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioclip;
    [SerializeField]
    private AudioSource Pop;
    public void PopPlay()
    {
        Pop.PlayOneShot(audioclip);
    }
}
