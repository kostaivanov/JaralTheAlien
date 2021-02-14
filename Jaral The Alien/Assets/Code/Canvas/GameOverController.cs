using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private AdMobManager adMobManager;
    [SerializeField] private AdMobBannerManager adMobLoading;

    [SerializeField] private GameObject allMovingObjects, player;
    [SerializeField] internal Text scoreText;
    internal int score = 0;
    [SerializeField] private GameObject goObj, coolObj, goodObj, awesomeObj, godlike_Obj;
    private Animator goAnimator, coolAnimator, goodAnimator, awesomeAnimator, godlikeAnimator;
    private MeshRenderer goMesh, coolMesh, goodMesh, awesomeMesh, godlikeMesh;

    [SerializeField] private Button retryButton, homeButton;
    [SerializeField] private Image retryImage, homeImage;
    [SerializeField] private Text retryText, homeText, gameOverText, pointsText;

    [SerializeField] private PlayerSoundController playerSoundController;


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
    }

    private void OnEnable()
    {
        adMobLoading.RequestBigBanner();

        if (PermanentFunctions.instance.lives == 0)
        {
            //Request rewarded video ad
            adMobManager.RequestRewardBasedVideo();
        }

        if (PermanentFunctions.instance.homeButtonClicks == 0)
        {
            //Request rewarded video ad
            adMobManager.RequestInterstitial();
        }

        Application.targetFrameRate = 30;
        StopAllCoroutines();

        allMovingObjects.SetActive(false);
        player.SetActive(false);
        score = PermanentFunctions.instance.score;
        scoreText.text = "Score: " + score.ToString();
        playerSoundController.StopSoundMovingShip();

        retryButton.enabled = true;
        homeButton.enabled = true;

        retryImage.enabled = true;
        homeImage.enabled = true;

        retryText.enabled = true;
        homeText.enabled = true;

        gameOverText.enabled = true;
        pointsText.enabled = true;


        //if (goAnimator != null && goAnimator.GetCurrentAnimatorStateInfo(0).IsName("GO!"))
        //{
        //    //goAnimator.enabled = false;
        //    //goMesh.enabled = false;
        //}
        //else if (coolAnimator != null && coolAnimator.GetCurrentAnimatorStateInfo(0).IsName("COOL!"))
        //{
        //    //coolAnimator.enabled = false;
        //    coolMesh.enabled = false;
        //}
        //else if (goodAnimator != null && goodAnimator.GetCurrentAnimatorStateInfo(0).IsName("GOOD!"))
        //{
        //    //goodAnimator.enabled = false;
        //    goodMesh.enabled = false;
        //}
        //else if (awesomeAnimator != null && awesomeAnimator.GetCurrentAnimatorStateInfo(0).IsName("AWESOME!"))
        //{
        //    //awesomeAnimator.enabled = false;
        //    awesomeMesh.enabled = false;
        //}
        //else if (godlikeAnimator != null && godlikeAnimator.GetCurrentAnimatorStateInfo(0).IsName("GODLIKE!"))
        //{
        //    //godlikeAnimator.enabled = false;
        //    godlikeMesh.enabled = false;
        //}
    }

    private void OnDisable()
    {
        Application.targetFrameRate = 60;
        if (allMovingObjects != null & player != null)
        {
            allMovingObjects.SetActive(true);
            player.SetActive(true);
        }
        scoreText.text = String.Empty;
        if (playerSoundController != null)
        {
            playerSoundController.PlaySoundIdleShip();
        }
    }
}
