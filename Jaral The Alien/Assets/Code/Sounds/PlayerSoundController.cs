using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField] internal AudioSource playAS, secondASmove, meteoriteAS;
    [SerializeField] internal AudioClip playSoundItem, playSoundDying, soundBreakMeteorite, soundBreakShip, soundIdleShip;

    internal void PlaySoundTakenItem()
    {
        playAS.PlayOneShot(playSoundItem);
    }

    internal void PlaySoundDead()
    {
        playAS.PlayOneShot(playSoundDying);
    }

    internal void PlaySoundBreakMeteorite()
    {
        meteoriteAS.PlayOneShot(soundBreakMeteorite);
    }

    internal void PlaySoundBreakShip()
    {
        playAS.PlayOneShot(soundBreakShip);
    }

    internal void PlaySoundIdleShip()
    {
        secondASmove.clip = soundIdleShip;
        secondASmove.Play();
        secondASmove.loop = true;
        secondASmove.volume = 0.2f;
        secondASmove.pitch = 1f;
    }

    internal void PlaySoundMovingShip()
    {
        secondASmove.pitch = 1.2f;
        secondASmove.volume = 0.3f;
    }

    internal void ReturnToIdleSound()
    {
        secondASmove.pitch = 1f;
        secondASmove.volume = 0.2f;
    }

    internal void StopSoundMovingShip()
    {
        if (secondASmove.isPlaying)
        {
            secondASmove.Stop();
        }       
    }
}
