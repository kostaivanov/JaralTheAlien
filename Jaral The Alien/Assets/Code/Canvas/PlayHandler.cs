using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private Animator goAnimator, coolAnimator, goodAnimator, awesomeAnimator, godlikeMesh;
    [SerializeField] private SpriteRenderer player;
    private PlayerHealth playerHealth;

    [SerializeField] private GameObject loadingObj;
    [SerializeField] private Button volumeButton, settingsButton, playButton, RecordsButton, exitButton, instructionsButton;
    [SerializeField] private Image volumeImg, settingsImg, playImg, RecordsImg, exitImg, instructionsImg;
    [SerializeField] private Text playTxt, RecordsTxt, exitTxt, instructionsTxt;

    private void Start()
    {
        goAnimator.gameObject.SetActive(false);
        coolAnimator.gameObject.SetActive(false);
        goodAnimator.gameObject.SetActive(false);
        awesomeAnimator.gameObject.SetActive(false);
        godlikeMesh.gameObject.SetActive(false);

        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        playerHealth.nextDamage = 0f;
    }

    //private void Update()
    //{
    //    Debug.Log(this.animatorGo.GetCurrentAnimatorStateInfo(0).IsName("GO!"));
    //    if(this.animatorGo.GetCurrentAnimatorStateInfo(0).IsName("GO!"))
    //    {
    //        animatorGo.gameObject.SetActive(false);
    //    }
    //}

    public void OnPointerDown(PointerEventData eventData)
    {      
        StartCoroutine(LoadingScene());

        if (player.enabled == false)
        {
            player.enabled = true;
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
        

        if (player.gameObject != null)
        {
            player.gameObject.GetComponent<PlayerHealth>().ResetPlayerValues();
        }
        PermanentFunctions.instance.score = 0;
        scoreController.scoreText.text = PermanentFunctions.instance.score.ToString();
    }

    internal IEnumerator LoadingScene()
    {
        loadingObj.SetActive(true);

        volumeButton.enabled = false;
        settingsButton.enabled = false;
        playButton.enabled = false;
        RecordsButton.enabled = false;
        exitButton.enabled = false;
        instructionsButton.enabled = false;

        volumeImg.enabled = false;
        settingsImg.enabled = false;
        playImg.enabled = false;
        RecordsImg.enabled = false;
        exitImg.enabled = false;
        instructionsImg.enabled = false;

        playTxt.enabled = false;
        RecordsTxt.enabled = false;
        exitTxt.enabled = false;
        instructionsTxt.enabled = false;

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;

        //yield return SceneManager.LoadSceneAsync(0);
        yield return new WaitForSecondsRealtime(2f);

        goAnimator.gameObject.SetActive(true);
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        canvasManager.SwitchCanvas(CanvasType.InGame);
        loadingObj.SetActive(false);
    }
}
