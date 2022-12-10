using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.loop = sound.loop;
        }
    }

    public void Play(string clipName)
    {
        if (sounds == null) return;
        Sound sound = sounds.FirstOrDefault(sound => sound.soundName == clipName);
        if (sound == null) return;
        sound.audioSource.Play();
    }
}
