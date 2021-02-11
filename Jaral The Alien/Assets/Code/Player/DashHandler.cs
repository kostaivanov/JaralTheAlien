using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DashHandler : MonoBehaviour, IPointerClickHandler
{
    internal bool dashButtonClicked = false;
    [SerializeField] private GameObject player;
    private Rigidbody2D rigidBody;
    private PlayerMovement playerMovement;
    [SerializeField] private float dashMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        rigidBody = player.GetComponent<Rigidbody2D>();
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{

    //}

    //public void OnPointerClick(PointerEventData eventData)
    //{

    //if (playerMovement.localVelocity.x > 0)
    //{

    //    Debug.Log(playerMovement.localVelocity.x);
    //}
    //else if (playerMovement.localVelocity.x < 0)
    //{
    //    rigidBody.AddForce(Vector2.left * dashMultiplier, ForceMode2D.Impulse);
    //}
    //else if (playerMovement.localVelocity.y > 0)
    //{
    //    rigidBody.AddForce(Vector2.up * dashMultiplier, ForceMode2D.Impulse);
    //}
    //else if (playerMovement.localVelocity.y < 0)
    //{
    //    rigidBody.AddForce(Vector2.down * dashMultiplier, ForceMode2D.Impulse);
    //}
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        dashButtonClicked = true;
    }
}
