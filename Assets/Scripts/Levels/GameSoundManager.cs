using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    public static GameSoundManager SoundInstance = null;
    private AudioSource SoundEffectAudio;

    public AudioClip keyCollected;
    public AudioClip keyNearbyClip;
    private void Start()
    {
        if (SoundInstance == null)
        {
            SoundInstance = this;
        }
        else if (SoundInstance != this)
        {
            Destroy(gameObject);
        }

        SoundEffectAudio = GetComponent<AudioSource>();

        //AudioSource[] sources = GetComponents<AudioSource>();
        //foreach (AudioSource source in sources)
        //{
        //    if (source.clip == null)
        //    {
        //        SoundEffectAudio = source;
        //    }
        //}
    }

    public void PlayOneShot(AudioClip clip)
    {
        SoundEffectAudio.PlayOneShot(clip);
    }
}
