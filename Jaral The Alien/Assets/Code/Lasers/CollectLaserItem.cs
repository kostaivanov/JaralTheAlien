using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLaserItem : MonoBehaviour
{
    private MeteoriteController meteoriteController;

    private float timeStamp;
    private bool flyToPlayer;
    private Vector2 playerDirection;
    private GameObject player;
    private Rigidbody2D rigidBody;
    private LaserItemsController laserItemController;

    private void Start()
    {
        meteoriteController = GetComponent<MeteoriteController>();
        rigidBody = GetComponent<Rigidbody2D>();
        laserItemController = GetComponent<LaserItemsController>();
    }


    private void Update()
    {
        if (flyToPlayer == true && player != null)
        {
            playerDirection = -(transform.position - player.transform.position).normalized;
            rigidBody.velocity = new Vector2(playerDirection.x, playerDirection.y) * 15f * (Time.time / timeStamp);
            //this.transform.position = Vector3.Lerp(transform.position, player.transform.position, 10f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player" && otherObject.GetComponent<PlayerHealth>().IsDead == false)
        {
            laserItemController.Disable();
            flyToPlayer = false;
        }

        if (otherObject.tag == "Magnet" && otherObject.GetComponentInParent<PlayerHealth>().IsDead == false)
        {
            timeStamp = Time.time;
            flyToPlayer = true;
            player = otherObject.gameObject.transform.parent.gameObject;
            laserItemController.move = false;
        }
    }
}
