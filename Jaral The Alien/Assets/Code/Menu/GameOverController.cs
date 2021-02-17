using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private AdMobManager adMobManager;
    [SerializeField] private AdMobBannerManager adMobLoading;

    [SerializeField] private GameObject allMovingObjects, player;

    [SerializeField] internal Text scoreText;
    internal int score = 0;

    [SerializeField] private Button retryButton, homeButton;
    [SerializeField] private Image retryImage, homeImage;
    [SerializeField] private Text retryText, homeText, gameOverText, pointsText;

    [SerializeField] private PlayerSoundController playerSoundController;

    private void OnEnable()
    {
        adMobLoading.RequestBigBanner();

        if (PermanentFunctions.instance.retryClicks == 0)
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
