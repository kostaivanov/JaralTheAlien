using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    internal int health = 90;
    private int damage => 30;
    private bool hastakenDamage;

    [SerializeField] private CanvasManager canvasManager;

    [SerializeField] private GameObject greenShell, redShell, engineFire;
    [SerializeField] private float damageRate;
    [SerializeField] private Sprite brokenShip, wholeShip;
    [SerializeField] private GameObject smokeEffect, brokeGlass, destroyShipEffect, breakMeteorite;
    private GameObject clone_brokeGlass, clone_destroyShipEffect, clone_BreakMeteorite;
    internal float nextDamage;
    private SpriteRenderer spriteRenderer;
    private ShakeObjectWhenDamaged shakeObject;
    [SerializeField] private Slider lasersCountSlider, bigBlastSlider;
    private PlayerMovement playerMovement;
    private PlayerSoundController playerSoundController;
    internal Vector3 startingPosition = new Vector2(-5f, 0);
    private bool gotLaser = false;
    private int laserCount = 0;

    [SerializeField] private CapsuleCollider2D magnetCapsuleCollider;
    [SerializeField] private CircleCollider2D playerTriggerCollider;
    private bool isDead;

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }


    private void Awake()
    {
        //startingPosition = this.transform.position;
        Debug.Log(this.transform.position);
    }

    private void Start()
    {
        IsDead = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
        shakeObject = GetComponent<ShakeObjectWhenDamaged>();
        playerMovement = GetComponent<PlayerMovement>();
        playerSoundController = GetComponent<PlayerSoundController>();

        greenShell.SetActive(false);
        redShell.SetActive(false);

        smokeEffect.SetActive(false);
        nextDamage = 0f;
        //startingPosition = this.transform.position;
        lasersCountSlider.maxValue = PermanentFunctions.instance.laserCount_Max;
        lasersCountSlider.value = 0;
        bigBlastSlider.maxValue = PermanentFunctions.instance.laserBigBlastCount_Max;
        bigBlastSlider.value = 0;
    }

    private void Update()
    {
        Debug.Log(PermanentFunctions.instance.lives);
        if(PermanentFunctions.instance.laserCount <= 0)
        {
            PermanentFunctions.instance.canShoot = false;
        }

        if (PermanentFunctions.instance.laserBigBlastCount <= 0)
        {
            PermanentFunctions.instance.canShootBigBlast = false;
        }
        //Debug.Log("can shoot bool - " + PermanentFunctions.instance.canShoot);
        //Debug.Log("can big shoot bool - " + PermanentFunctions.instance.canShootBigBlast);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "LaserItem")
        {
            greenShell.SetActive(true);
            PermanentFunctions.instance.laserCount = 20;
            lasersCountSlider.value = PermanentFunctions.instance.laserCount;
            PermanentFunctions.instance.canShoot = true;
            //StartCoroutine(WaitUntilDisable());
            Invoke("WaitUntilDisableGreenShell", 3f);
        }

        if (otherObject.tag == "LaserItemBigBlast")
        {
            if (laserCount == 0)
            {
                PermanentFunctions.instance.canShootBigBlast = true;
                redShell.SetActive(true);
                PermanentFunctions.instance.laserBigBlastCount = 1;
                bigBlastSlider.value = PermanentFunctions.instance.laserBigBlastCount;
                //Debug.Log("red");
                PermanentFunctions.instance.canShoot = false;
                //StartCoroutine(WaitUntilDisable());
                Invoke("WaitUntilDisableRedShell", 3f);
                laserCount++;
            }  
        }
        
        if (nextDamage < Time.time)
        {
            if (otherObject.tag == "SmallMeteorite")
            {
                TakeDamage();
                playerSoundController.PlaySoundBreakMeteorite();
                nextDamage = Time.time + damageRate;
                clone_BreakMeteorite = Instantiate(breakMeteorite, otherObject.transform.position, Quaternion.identity);
                otherObject.gameObject.SetActive(false);
               
                Destroy(clone_BreakMeteorite, 0.5f);
            }
            else if (otherObject.tag == "MediumMeteorite" || otherObject.tag == "BigMeteorite")
            {
                KillPlayerAndRestartGame();
                
                nextDamage = Time.time + damageRate;
                clone_BreakMeteorite = Instantiate(breakMeteorite, otherObject.transform.position, Quaternion.identity);
                Destroy(clone_BreakMeteorite, 0.5f);
            }          
        }
    }

    private void OnTriggerExit2D(Collider2D otherObject)
    {
        if (laserCount == 1 && otherObject.tag == "LaserItemBigBlast")
        {
            laserCount = 0;
        }
    }

    public void TakeDamage()
    {

        if (damage <= 0)
        {
            return;
        }

        health -= damage;

        shakeObject.BeginShakingObject();
        if (health == 60)
        {
            ShakeCamera.Shake(0.5f, 0.1f);
            smokeEffect.SetActive(true);
        }
        if (health == 30)
        {
            clone_brokeGlass = Instantiate(brokeGlass, this.transform.position, Quaternion.identity);
            Destroy(clone_brokeGlass, 0.5f);
            spriteRenderer.sprite = brokenShip;
            ShakeCamera.Shake(0.5f, 0.1f);
            playerSoundController.PlaySoundBreakShip();
        }
        if (health == 0)
        {
            
            KillPlayerAndRestartGame();
        }

    }

    private void KillPlayerAndRestartGame()
    {
        IsDead = true;

        magnetCapsuleCollider.enabled = false;
        playerTriggerCollider.enabled = false;

        //if (PermanentFunctions.instance.lives == 0)
        //{
        //    PermanentFunctions.instance.lives = 3;

        //}
        //PermanentFunctions.instance.lives--;


        playerSoundController.PlaySoundDead();
        playerSoundController.StopSoundMovingShip();
        playerMovement.idlePlayed = false;
        ShakeCamera.Shake(0.5f, 1f);
        Handheld.Vibrate();
        

        playerMovement.enabled = false;
        clone_destroyShipEffect = Instantiate(destroyShipEffect, this.gameObject.transform.position, destroyShipEffect.transform.rotation, this.gameObject.transform);
        Destroy(clone_destroyShipEffect, 1.2f);

        PermanentFunctions.instance.canShoot = false;
        PermanentFunctions.instance.canShootBigBlast = false;
        PermanentFunctions.instance.laserCount = 0;
        PermanentFunctions.instance.laserBigBlastCount = 0;

        lasersCountSlider.value = 0;
        bigBlastSlider.value = 0;
        spriteRenderer.enabled = false;

        Physics2D.IgnoreLayerCollision(8, 9, true);

        smokeEffect.SetActive(false);
        if (greenShell.activeInHierarchy || redShell.activeInHierarchy)
        {
            greenShell.SetActive(false);
            redShell.SetActive(false);
        }
        engineFire.SetActive(false);

        StartCoroutine(WaitUntilRestartGame());
    }

    private void WaitUntilDisableGreenShell()
    {
        
        //yield return new WaitForSecondsRealtime(3f);
        greenShell.SetActive(false);

    }

    private void WaitUntilDisableRedShell()
    {
        redShell.SetActive(false);
    }

    private IEnumerator WaitUntilRestartGame()
    {
        yield return new WaitForSeconds(1.5f);
        ResetPlayerValues();
        canvasManager.SwitchCanvas(CanvasType.GameOverMenu);
    }

    internal void ResetPlayerValues()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = wholeShip;
        }
        
        engineFire.SetActive(true);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        this.transform.position = startingPosition;
        PermanentFunctions.instance.meteoriteSpeed = PermanentFunctions.instance.initialMeteoriteSpeed;
        //PermanentFunctions.instance.starsStartSpeedDefault = PermanentFunctions.instance.starsInitialSpeed;
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
            playerMovement.idlePlayed = false;
        }

        magnetCapsuleCollider.enabled = true;
        playerTriggerCollider.enabled = true;

        health = 90;
        IsDead = false;
    }
}
