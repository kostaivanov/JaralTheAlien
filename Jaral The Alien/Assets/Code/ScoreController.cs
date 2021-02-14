using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] internal Text scoreText;
    private float timer, yuppieTimer;
    internal int score = 0;
    internal float yuppieTime = 0f;
    internal int yuppieScore = 0;
    [SerializeField] private AudioSource canvasAS;
    [SerializeField] private AudioClip yupppieSound;
    //[SerializeField] private GameObject inGame;
    private bool subscribed;
    private bool unsubscribed;

    private void Start()
    {
        score = PermanentFunctions.instance.score;
        scoreText.text = score.ToString();
        subscribed = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        yuppieTimer += Time.deltaTime;

        if (timer > 1f)
        {
            PermanentFunctions.instance.score += 10;
            score = PermanentFunctions.instance.score;
            //We only need to update the text if the score changed.
            scoreText.text = score.ToString();
            //Reset the timer to 0.
            timer = 0;
        }
        if (yuppieTimer > 1f)
        {
            var difference = score - yuppieScore;
            if (difference > 50 && canvasAS.isPlaying == false)
            {
                canvasAS.PlayOneShot(yupppieSound);
                Debug.Log("Yuppie - " + yuppieScore);
                
            }
            yuppieScore = score;
            yuppieTimer = 0f;
        }


        //if (inGame.activeSelf == true && subscribed == false)
        //{
        //    MeteoriteHealthController.OnMeteoriteBreak += CountYuppieTime;
        //    subscribed = true;
        //}
        //else if(inGame.activeSelf == false && subscribed == true)
        //{
        //    MeteoriteHealthController.OnMeteoriteBreak -= CountYuppieTime;

        //    subscribed = false;
        //}
    }

    internal IEnumerator CountYuppieTime()
    {
        //if (yuppieTime > 3f)
        //{
        //    yuppieScore = score;
        //    yuppieTime += 1 * Time.deltaTime;
        //}

        yuppieScore = score;
        Debug.Log(yuppieScore);
        yield return new WaitForSecondsRealtime(2f);
        if (score - yuppieScore >= 100)
        {
            canvasAS.PlayOneShot(yupppieSound);
            yuppieScore = 0;
        }
        else
        {
            yuppieScore = 0;
        }
    }
}
