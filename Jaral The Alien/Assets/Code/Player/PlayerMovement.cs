using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] internal Rigidbody2D rigidBody;
    [SerializeField] internal DashHandler dashButton;
    [SerializeField] internal JoystickController joyStickController;
    [SerializeField] internal Joystick joystick;
    [SerializeField] internal Movehandler moveHandlerUp, moveHandlerDown;
    private PlayerSoundController playerSoundController;
    private PlayerHealth playerHealth;

    private float move_Y, joystick_Y;

    private Vector2 moveDirectionJoystick, moveDirectionButtons;
    private bool isMoving = false;
    internal bool canDash = false;
    private bool soundMoveShipPlayed = false;
    //private Vector3 touchPosition;
    //private float delta_X, delta_Y;
    //private bool canMove = false;
    internal Vector3 localVelocity;
    private float dash = 1f;
    internal bool idlePlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerSoundController = GetComponent<PlayerSoundController>();
        playerHealth = GetComponent<PlayerHealth>();
        idlePlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf == true && playerHealth.health > 0 && idlePlayed == false && isMoving == false)
        {
            playerSoundController.PlaySoundIdleShip();
            idlePlayed = true;
        }

        if (Input.anyKey)
        {
            ProcessInput();         
        }
        else
        {
            //rigidBody.velocity = Vector2.zero;
            isMoving = false;
            //playerSoundController.StopSoundMovingShip();
            soundMoveShipPlayed = false;
            playerSoundController.ReturnToIdleSound();
        }

        if (dashButton.dashButtonClicked)
        {
            if (isMoving == true)
            {
                dash = 12f;
            }
            else
            {
                dash = 1f;
            }

            dashButton.dashButtonClicked = false;
        }

        if (isMoving == true)
        {
            if (joystick.gameObject.activeSelf == true)
            {
                Move(moveDirectionJoystick);
            }
            else
            {
                Move(moveDirectionButtons);
            }
            
            
            //moveKeyIsPressed = false;
        }
    }


    //private void FixedUpdate()
    //{        
    //    if (isMoving == true)
    //    {
    //        Move();
    //        moveKeyIsPressed = false;
    //    }
    //}

    private void ProcessInput()
    {
        if (moveHandlerUp.moveButtonPressed)
        {
            //move_X = 0f;
            move_Y = 1f;
        }
        else if (moveHandlerDown.moveButtonPressed)
        {
            //move_X = 0f;
            move_Y = -1f;
        }
        else
        {
            move_Y = 0f;
        }
        //move_X = Input.GetAxisRaw("Horizontal");
        //move_Y = Input.GetAxisRaw("Vertical");

        //joystick_X = joystick.Horizontal;
        joystick_Y = joystick.Vertical;

        moveDirectionButtons = new Vector2(0, move_Y).normalized;
        moveDirectionJoystick = new Vector2(0, joystick_Y).normalized;
        isMoving = true;
        //moveKeyIsPressed = true;

        if (soundMoveShipPlayed == false)
        {
            playerSoundController.PlaySoundMovingShip();
            soundMoveShipPlayed = true;
        }
    }

    private void Move(Vector2 direction)
    {
        //rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed  * dash, moveDirection.y * moveSpeed * dash);
        //transform.position += new Vector3(moveDirection.x * moveSpeed * Time.deltaTime, moveDirection.y * moveSpeed * Time.deltaTime);
        transform.Translate(new Vector2(direction.x * moveSpeed * Time.deltaTime, direction.y * moveSpeed * dash * Time.deltaTime));

        if (dash > 1f)
        {
            dash = 1f;
        }
        localVelocity = transform.TransformDirection(rigidBody.velocity);
    }
}
