using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private AdMobBannerManager adMobLoading;

    [SerializeField] private GameObject allMovingObjects, player, loadingObj;
    //private PlayerHealth playerHealth;
    [SerializeField] private Button volumeButton, settingsButton, playButton, RecordsButton, exitButton, instructionsButton;
    [SerializeField] private Image volumeImg, settingsImg, playImg, RecordsImg, exitImg, instructionsImg;
    [SerializeField] private Text playTxt, RecordsTxt, exitTxt, instructionsTxt;

    // Start is called before the first frame update
    //void Start()
    //{
    //    if (player != null)
    //    {
    //        playerHealth = player.GetComponent<PlayerHealth>();
    //    }

    //}

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

        //if (starsBackground != null)
        //{
        //    var main = starsBackground.main;
        //    main.simulationSpeed = 1.0f;
        //}
    }

    //private void OnDisable()
    //{
    //    Application.targetFrameRate = 60;
    //    if (allMovingObjects != null & player != null)
    //    {
    //        allMovingObjects.SetActive(true);
    //        player.SetActive(true);
    //    }
    //}
}
