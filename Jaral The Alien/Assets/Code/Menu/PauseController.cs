using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseController : MonoBehaviour
{
    [SerializeField] private AdMobManager adMobManager;

    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject goObject, coolObject, goodObject, awesomeObject, godlikeObject;
    private Animator goAnimator, coolAnimator, goodAnimator, awesomeAnimator, godlikeAnimator;
    private MeshRenderer goMesh, coolMesh, goodMesh, awesomeMesh, godlikeMesh;
    [SerializeField] private PlayerSoundController playerSoundController;

    private void Awake()
    {
        goAnimator = goObject.GetComponent<Animator>();
        goMesh = goObject.GetComponent<MeshRenderer>();

        coolAnimator = coolObject.GetComponent<Animator>();
        coolMesh = coolObject.GetComponent<MeshRenderer>();

        goodAnimator = goodObject.GetComponent<Animator>();
        goodMesh = goodObject.GetComponent<MeshRenderer>();

        awesomeAnimator = awesomeObject.GetComponent<Animator>();
        awesomeMesh = awesomeObject.GetComponent<MeshRenderer>();

        godlikeAnimator = godlikeObject.GetComponent<Animator>();
        godlikeMesh = godlikeObject.GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        if (PermanentFunctions.instance.homeButtonClicks == 0)
        {
            //Request rewarded video ad
            adMobManager.RequestInterstitial();
        }

        Application.targetFrameRate = 30;
        Time.timeScale = 0;

        joystick.input = Vector2.zero;
        joystick.handle.anchoredPosition = Vector2.zero;

        playerSoundController.StopSoundMovingShip();

        if (goAnimator.GetCurrentAnimatorStateInfo(0).IsName("GO!"))
        {
            goAnimator.enabled = false;
            goMesh.enabled = false;
        }
        else if (coolAnimator != null && coolAnimator.GetCurrentAnimatorStateInfo(0).IsName("COOL!"))
        {
            coolAnimator.enabled = false;
            coolMesh.enabled = false;
        }
        else if (goodAnimator != null && goodAnimator.GetCurrentAnimatorStateInfo(0).IsName("GOOD!"))
        {
            goodAnimator.enabled = false;
            goodMesh.enabled = false;
        }
        else if (awesomeAnimator != null && awesomeAnimator.GetCurrentAnimatorStateInfo(0).IsName("AWESOME!"))
        {
            awesomeAnimator.enabled = false;
            awesomeMesh.enabled = false;
        }
        else if (godlikeAnimator != null && godlikeAnimator.GetCurrentAnimatorStateInfo(0).IsName("GODLIKE!"))
        {
            godlikeAnimator.enabled = false;
            godlikeMesh.enabled = false;
        }
    }

    private void OnDisable()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;

        if (playerSoundController != null)
        {
            playerSoundController.PlaySoundIdleShip();
        }
    }
}
