using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<Sound> sounds;

    private void Start()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
        }
    }

    public void PlaySound(string soundName)
    {
        var sound = sounds.Find(s => s.name == soundName);
        if (sound != null)
        {
            sound.source.Play();
        }
    }
}
