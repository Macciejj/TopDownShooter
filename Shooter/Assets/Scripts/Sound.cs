using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound {

    [HideInInspector]
    public AudioSource audioSource;
    public AudioClip audioClip;
    public string soundName;
    public float volume;
    public bool playOnAwake;
    public bool loop;

}
