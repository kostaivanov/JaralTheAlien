using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private AdMobBannerManager adMobLoading;

    [SerializeField] private GameObject allMovingObjects, player, loadingObj;

    [SerializeField] private Button volumeButton, settingsButton, playButton, RecordsButton, exitButton, instructionsButton;
    [SerializeField] private Image volumeImg, settingsImg, playImg, RecordsImg, exitImg, instructionsImg;
    [SerializeField] private Text playTxt, RecordsTxt, exitTxt, instructionsTxt;

    private void OnEnable()
    {
        adMobLoading.RequestBigBanner();

        Application.targetFrameRate = 30;

        allMovingObjects.SetActive(false);

        player.SetActive(false);

        StopAllCoroutines();

        loadingObj.SetActive(false);

        volumeButton.enabled = true;
        settingsButton.enabled = true;
        playButton.enabled = true;
        RecordsButton.enabled = true;
        exitButton.enabled = true;
        instructionsButton.enabled = true;

        volumeImg.enabled = true;
        settingsImg.enabled = true;
        playImg.enabled = true;
        RecordsImg.enabled = true;
        exitImg.enabled = true;
        instructionsImg.enabled = true;

        playTxt.enabled = true;
        RecordsTxt.enabled = true;
        exitTxt.enabled = true;
        instructionsTxt.enabled = true;
    }
}
