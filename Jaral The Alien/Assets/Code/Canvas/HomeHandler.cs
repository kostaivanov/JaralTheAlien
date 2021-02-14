using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class HomeHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] private AdMobManager adMobManager;

    //[SerializeField] private GameObject player;
    [SerializeField] private GameObject objectPoolerObj;
    [SerializeField] private Slider lasersCountSlider, bigBlastSlider;
    [SerializeField] private ParticleSystem starsBackground;
    private ObjectPooler objectPooler;
    [SerializeField] private GameController gameController;

    private void Start()
    {
        objectPooler = objectPoolerObj.GetComponent<ObjectPooler>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PermanentFunctions.instance.homeButtonClicks++;
        if (PermanentFunctions.instance.homeButtonClicks == 3)
        {
            PermanentFunctions.instance.homeButtonClicks = 0;
            //Show rewarded video ad
            adMobManager.ShowInterstitialAd();
        }

        if (this.transform.parent.gameObject.name == "InstructionsImage")
        {
            canvasManager.SwitchCanvas(CanvasType.Menu);
            return;
        }
        canvasManager.SwitchCanvas(CanvasType.Menu);

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
        ResetPlayerHealthValues();

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

    private void ResetPlayerHealthValues()
    {
        PermanentFunctions.instance.canShoot = false;
        PermanentFunctions.instance.canShootBigBlast = false;
        PermanentFunctions.instance.laserCount = 0;
        PermanentFunctions.instance.laserBigBlastCount = 0;

        lasersCountSlider.value = 0;
        bigBlastSlider.value = 0;
    }
}
