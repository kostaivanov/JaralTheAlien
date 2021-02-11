using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource playAS, shootAS, dashAS;
    [SerializeField] private AudioClip playSound, shootSound, bigLaserShootSound, dashSound;

    public void PlayButtonSound()
    {
        playAS.PlayOneShot(playSound);
    }


    public void PlaySoundFireShot()
    {
        if (PermanentFunctions.instance.canShootBigBlast == true)
        {
            shootAS.PlayOneShot(bigLaserShootSound);
            //Debug.Log("shoot big");
        }
        else if (PermanentFunctions.instance.canShoot == true)
        {
            shootAS.PlayOneShot(shootSound);
            //Debug.Log("shoot");
        }
    }
    public void PlaySoundDash()
    {
        dashAS.PlayOneShot(dashSound);
    }

}
