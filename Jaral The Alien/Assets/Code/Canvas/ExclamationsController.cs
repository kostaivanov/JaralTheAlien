﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationsController : MonoBehaviour
{
    [SerializeField] private GameObject goObj, coolObj, goodObj, awesomeObj, godlike_Obj;
    private Animator goAnimator, coolAnimator, goodAnimator, awesomeAnimator, godlikeAnimator;
    private MeshRenderer goMesh, coolMesh, goodMesh, awesomeMesh, godlikeMesh;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject inGame, gameOver, pauseMenu;

    private bool animationsOff;

    // Start is called before the first frame update
    void Start()
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
        animationsOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.activeSelf == true && animationsOff == false)
        {
            if (goAnimator != null && goAnimator.GetCurrentAnimatorStateInfo(0).IsName("GO!"))
            {
                //goAnimator.enabled = false;
                goMesh.enabled = false;
            }
            else if (coolAnimator != null && coolAnimator.GetCurrentAnimatorStateInfo(0).IsName("COOL!"))
            {
                //coolAnimator.enabled = false;
                coolMesh.enabled = false;
            }
            else if (goodAnimator != null && goodAnimator.GetCurrentAnimatorStateInfo(0).IsName("GOOD!"))
            {
                //goodAnimator.enabled = false;
                goodMesh.enabled = false;
            }
            else if (awesomeAnimator != null && awesomeAnimator.GetCurrentAnimatorStateInfo(0).IsName("AWESOME!"))
            {
                //awesomeAnimator.enabled = false;
                awesomeMesh.enabled = false;
            }
            else if (godlikeAnimator != null && godlikeAnimator.GetCurrentAnimatorStateInfo(0).IsName("GODLIKE!"))
            {
                //godlikeAnimator.enabled = false;
                godlikeMesh.enabled = false;
            }
            animationsOff = true;
        }

        if (animationsOff == true && inGame.activeSelf == true)
        {
            animationsOff = false;

            goMesh.enabled = true;
            coolMesh.enabled = true;
            goodMesh.enabled = true;
            awesomeMesh.enabled = true;
            godlikeMesh.enabled = true;

        }
    }
}
