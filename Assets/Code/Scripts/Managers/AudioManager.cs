using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx, music;

    public static AudioManager aMRef;

    private void Awake()
    {
        if(aMRef == null)
        {
            aMRef = this;
        }
    }
    
    public void PlaySFX(int soundToPlay)
    {
        sfx[soundToPlay].Stop();

        sfx[soundToPlay].Play();
    }
}
