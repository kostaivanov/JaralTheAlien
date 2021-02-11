using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    //[SerializeField] private ParticleSystem starsBackground;
    [SerializeField] private ToggleColorController buttonsControl, sliderControl;
    [SerializeField] private GameObject joystickObj, movementButtons, goObj, coolObj, goodObj, awesomeObj, godlike_Obj;
    private Animator goAnimator, coolAnimator, goodAnimator, awesomeAnimator, godlikeAnimator;
    private MeshRenderer goMesh, coolMesh, goodMesh, awesomeMesh, godlikeMesh;
    internal bool animationHasPlayed = false;
    internal bool coolHasPlayed, goodHasPlayed, awesomeHasPlayed, godlikeHasplayed = false;
    [SerializeField] private AudioSource canvas_AS;
    [SerializeField] private AudioClip[] labelSound;


    private void Start()
    {
        goAnimator = goObj.GetComponent<Animator>();
        goMesh = goObj.GetComponent<MeshRenderer>();

        coolAnimator = coolObj.GetComponent<Animator>();
        coolMesh = coolObj.GetComponent<MeshRenderer>();

        goodAnimator = goodObj.GetComponent<Animator>();
        goodMesh = goodObj.GetComponent<MeshRenderer>();

        awesomeAnimator = awesomeObj.GetComponent<Animator>();
        awesomeMesh = awesomeObj.GetComponent<MeshRenderer>();

        godlikeAnimator = godlike_Obj.GetComponent<Animator>();
        godlikeMesh = godlike_Obj.GetComponent<MeshRenderer>();

        coolHasPlayed = false;
        goodHasPlayed = false;
        awesomeHasPlayed = false;
        godlikeHasplayed = false;
    }

    private void OnEnable()
    {
        Application.targetFrameRate = 60;
        PermanentFunctions.instance.keepWaiting = true;
        StartCoroutine(PermanentFunctions.instance.IncreaseSpeedObjectAtIntervals(60f));
        PermanentFunctions.instance.OnIncreaseSpeed += PermanentFunctions.instance.IncreaseSpeedWithTime;

        if (buttonsControl.state == true)
        {
            joystickObj.SetActive(false);
            movementButtons.SetActive(true);
        }
        else if (sliderControl.state == true)
        {
            joystickObj.SetActive(true);
            movementButtons.SetActive(false);
        }

        if (goAnimator != null && goAnimator.GetCurrentAnimatorStateInfo(0).IsName("GO!"))
        {
            goAnimator.enabled = true;
            goMesh.enabled = true;
        }
        else if (coolAnimator != null && coolAnimator.GetCurrentAnimatorStateInfo(0).IsName("COOL!"))
        {
            coolAnimator.enabled = true;
            coolMesh.enabled = true;
        }
        else if (goodAnimator != null && goodAnimator.GetCurrentAnimatorStateInfo(0).IsName("GOOD!"))
        {
            goodAnimator.enabled = true;
            goodMesh.enabled = true;
        }
        else if (awesomeAnimator != null && awesomeAnimator.GetCurrentAnimatorStateInfo(0).IsName("AWESOME!"))
        {
            awesomeAnimator.enabled = true;
            awesomeMesh.enabled = true;
        }
        else if (godlikeAnimator != null && godlikeAnimator.GetCurrentAnimatorStateInfo(0).IsName("GODLIKE!"))
        {
            godlikeAnimator.enabled = true;
            godlikeMesh.enabled = true;
        }
    }

    private void OnDisable()
    {
        Application.targetFrameRate = 30;
        PermanentFunctions.instance.keepWaiting = false;

        ////if (starsBackground != null)
        ////{
        ////    var main = starsBackground.main;
        ////    main.simulationSpeed = 1.0f;
        ////}

        //joystickController.gameIsOn = false;
        PermanentFunctions.instance.OnIncreaseSpeed -= PermanentFunctions.instance.IncreaseSpeedWithTime;
        //if (animationGO.activeSelf == true)
        //{
        //    animationGO.SetActive(false);
        //}
    }

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if (PermanentFunctions.instance.score >= 200 && PermanentFunctions.instance.score < 400 && coolHasPlayed == false)
            {
                coolAnimator.gameObject.SetActive(true);
                coolHasPlayed = true;
                canvas_AS.PlayOneShot(labelSound[0]);
                //gameController_AS.volume = 1f;
            }
            else if(PermanentFunctions.instance.score >= 400 && PermanentFunctions.instance.score < 600 && goodHasPlayed == false)
            {
                goodAnimator.gameObject.SetActive(true);
                goodHasPlayed = true;
                canvas_AS.PlayOneShot(labelSound[2]);
            }
            else if (PermanentFunctions.instance.score >= 600 && PermanentFunctions.instance.score < 800 && awesomeHasPlayed == false)
            {
                awesomeAnimator.gameObject.SetActive(true);
                awesomeHasPlayed = true;
                canvas_AS.PlayOneShot(labelSound[1]);
            }
            else if (PermanentFunctions.instance.score >= 800 && godlikeHasplayed == false)
            {
                godlikeMesh.gameObject.SetActive(true);
                godlikeHasplayed = true;
                canvas_AS.PlayOneShot(labelSound[3]);
            }
        }
    }
}
