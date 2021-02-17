using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RetryHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] private AdMobManager adMobManager;
    [SerializeField] private AdMobBannerManager adMobLoading;

    [SerializeField] private Animator goAnimator;

   [SerializeField] private GameObject objectPoolerObj;
    [SerializeField] private ScoreController scoreController;
    private ObjectPooler objectPooler;

    [SerializeField] private ParticleSystem starsBackground;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject loadingObj;

    [SerializeField] private Button retryButton, homeButton;
    [SerializeField] private Image retryImage, homeImage;
    [SerializeField] private Text retryText, homeText, gameOverText, pointsText;


    private void Start()
    {
        objectPooler = objectPoolerObj.GetComponent<ObjectPooler>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PermanentFunctions.instance.retryClicks++;
        if (PermanentFunctions.instance.retryClicks == 3)
        {
            PermanentFunctions.instance.retryClicks = 0;
            //Show rewarded video ad
            adMobManager.ShowVideoRewardAd();
        }
        else
        {
            adMobLoading.ShowBigBannerAd();
        }

        StartCoroutine(LoadingScene());

        foreach (GameObject pooledObj in objectPooler.pooledObjects)
        {
            if (pooledObj.tag == "SmallMeteorite" || pooledObj.tag == "MediumMeteorite" || pooledObj.tag == "BigMeteorite")
            {
                pooledObj.transform.position = pooledObj.GetComponent<MeteoriteController>().startPosition;
                pooledObj.SetActive(false);
            }
            else if (pooledObj.tag == "LaserItem" || pooledObj.tag == "LaserItemBigBlast")
            {
                pooledObj.transform.position = pooledObj.GetComponent<LaserItemsController>().startPosition;
                pooledObj.SetActive(false);
            }
        }

        PermanentFunctions.instance.score = 0;
        scoreController.scoreText.text = PermanentFunctions.instance.score.ToString();

        if (starsBackground != null)
        {
            var main = starsBackground.main;
            main.simulationSpeed = 1.0f;
        }

        gameController.coolHasPlayed = false;
        gameController.goodHasPlayed = false;
        gameController.awesomeHasPlayed = false;
        gameController.godlikeHasplayed = false;

     
    }

    internal IEnumerator LoadingScene()
    {
        loadingObj.SetActive(true);

        retryButton.enabled = false;
        homeButton.enabled = false;

        retryImage.enabled = false;
        homeImage.enabled = false;

        retryText.enabled = false;
        homeText.enabled = false;

        gameOverText.enabled = false;
        pointsText.enabled = false;

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

        adMobLoading.DestroyBigBannerAd();
    }
}
