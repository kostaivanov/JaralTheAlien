using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserItemsController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    internal Vector2 startPosition;
    internal bool move = false;
    private bool played = false;

    void Start()
    {
        startPosition = this.transform.position;

        rigidBody = GetComponent<Rigidbody2D>();
        //rigidBody.velocity = Vector2.left * PermanentFunctions.instance.meteoriteSpeed;
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player")
        {
            if (played == false)
            {
                otherObject.gameObject.GetComponent<PlayerSoundController>().PlaySoundTakenItem();
                played = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player")
        {
            played = false;
        }
    }

    private void OnEnable()
    {
        move = true;

        Invoke("Disable", 3f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    internal void Disable()
    {
        this.gameObject.SetActive(false);
        move = false;
    }

    private void FixedUpdate()
    {
        if (move == true)
        {
            if (rigidBody != null)
            {
                rigidBody.velocity = Vector2.left * PermanentFunctions.instance.meteoriteSpeed;
            }
        }
    }
}
