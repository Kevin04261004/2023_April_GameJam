using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Manager : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioclip;
    [SerializeField]
    private AudioSource BGM;
    public void Awake()
    {
        BGMPlay();
    }

    public void BGMPlay()
    {
        BGM.PlayOneShot(audioclip);
    }
}
