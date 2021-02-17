using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private GameObject allMovingObjects, player;
    //[SerializeField] private CanvasManager canvasManager;
    //[SerializeField] private Animator goAnimator;

    private void OnDisable()
    {
        Application.targetFrameRate = 60;
        if (allMovingObjects != null & player != null)
        {
            allMovingObjects.SetActive(true);
            player.SetActive(true);
        }
    } 
}
