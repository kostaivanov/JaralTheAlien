using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteHealthController : MonoBehaviour
{
    [SerializeField] internal float health;
    [SerializeField] private GameObject breakSmallMeteoEff_Green, breakMediumMeteoEff_Green, breakBigMeteoEff_Red, breakSmallMeteoEff_Red, breakMediumMeteoEff_Red;
    private GameObject clone_breakSmallMeteoEff_Green, clone_breakMediumMeteoEff_Green, clone_breakBigMeteoEff_Red, clone_breakSmallMeteoEff_Red, clone_breakMediumMeteoEff_Red;
    private AudioSource meteoriteAS;
    [SerializeField] private AudioClip breakMeteoriteSound, hitMeteoriteSound;

    internal float fullHealthSmallMeteorite => 10;
    internal float fullHealthMediumMeteorite => 20f;
    internal float fullHealthBigMeteorite => 50f;

    //public delegate IEnumerator CountYuppieScore();
    //public static event CountYuppieScore OnMeteoriteBreak;

    private void Start()
    {
        meteoriteAS = GetComponentInParent<AudioSource>();
        meteoriteAS.volume = 0.35f;
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "SmallLaser")
        {
            meteoriteAS.PlayOneShot(hitMeteoriteSound);
          
            if (this.gameObject.tag == "SmallMeteorite" || this.gameObject.tag == "MediumMeteorite")
            {
                health -= 10;
                
                if (health <= 0)
                {
                    SelectBreakMeteoriteEffect("SmallLaser");
                    
                    otherObject.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                    return;
                }               
            }
            otherObject.gameObject.SetActive(false);
        }

        if (otherObject.tag == "BigLaser")
        {
            if (this.gameObject.tag == "SmallMeteorite" || this.gameObject.tag == "MediumMeteorite" || this.gameObject.tag == "BigMeteorite")
            {

                SelectBreakMeteoriteEffect("BigLaser");
                
                //otherObject.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                return;
            }
            //otherObject.gameObject.SetActive(false);
        }
    }

    private void SelectBreakMeteoriteEffect(string laserType)
    {
        meteoriteAS.PlayOneShot(breakMeteoriteSound);
        //StartCoroutine(OnMeteoriteBreak());
        ShakeCamera.Shake(0.5f, 0.1f);

        switch (this.gameObject.tag)
        {            
            case "SmallMeteorite":
                if (laserType == "BigLaser")
                {
                    clone_breakSmallMeteoEff_Red = Instantiate(breakSmallMeteoEff_Red, this.transform.position, Quaternion.identity);
                    Destroy(clone_breakSmallMeteoEff_Red, 1.3f);
                }
                else if (laserType == "SmallLaser")
                {
                    clone_breakSmallMeteoEff_Green = Instantiate(breakSmallMeteoEff_Green, this.transform.position, Quaternion.identity);
                    Destroy(clone_breakSmallMeteoEff_Green, 0.3f);
                }
                PermanentFunctions.instance.score += 20;
                break;
            case "MediumMeteorite":
                if (laserType == "BigLaser")
                {
                    clone_breakMediumMeteoEff_Red = Instantiate(breakMediumMeteoEff_Red, this.transform.position, Quaternion.identity);
                    Destroy(clone_breakMediumMeteoEff_Red, 1.3f);
                }
                else if (laserType == "SmallLaser")
                {
                    clone_breakMediumMeteoEff_Green = Instantiate(breakMediumMeteoEff_Green, this.transform.position, Quaternion.identity);
                    Destroy(clone_breakMediumMeteoEff_Green, 0.3f);
                }
                PermanentFunctions.instance.score += 30;
                break;
            case "BigMeteorite":
                if (laserType == "BigLaser")
                {
                    clone_breakBigMeteoEff_Red = Instantiate(breakBigMeteoEff_Red, this.transform.position, Quaternion.identity);
                    Destroy(clone_breakBigMeteoEff_Red, 1.3f);
                }
                PermanentFunctions.instance.score += 40;
                break;
        }
    }
}
