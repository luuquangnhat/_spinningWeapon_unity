using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class ManagerCharacterMovingPosition : MonoBehaviour
{
    // variable to store the instance of the PlayerInput
    PlayerInput input;
    private float velocity;
    private float acceleration = 2f;
    Vector3 storeDirection;

    private bool isMain;

    public bool IsMain
    {
        get
        {
            return isMain;
        }
        set
        {
            isMain = value;
            if (value)
            {
                input.CharacterControls.Movement.performed += ctx =>
                {
                    //Debug.Log($"ctx {ctx.ReadValue<Vector2>()}");
                    currentDirection = ctx.ReadValue<Vector2>();
                };
                input.CharacterControls.Movement.canceled += ctx =>
                {
                    currentDirection = ctx.ReadValue<Vector2>();
                };
            }
            else
            {
                input.CharacterControls.Movement.performed -= ctx =>
                {
                    //Debug.Log($"ctx {ctx.ReadValue<Vector2>()}");
                    currentDirection = ctx.ReadValue<Vector2>();
                };
                input.CharacterControls.Movement.canceled -= ctx =>
                {
                    currentDirection = ctx.ReadValue<Vector2>();
                };
            }
        }
    }

    // variable to store player input values
    Vector2 currentDirection;
    void Awake()
    {
        input = new PlayerInput();
    }

    //public float speed = 10f ;
    // Update is called once per frame
    void Update()
    {
        handleMovement();
        //handleRotation();
    }
    void handleMovement()
    {
        if (currentDirection != Vector2.zero && isMain)
        {
            Vector3 move = new Vector3(currentDirection.x, 0, currentDirection.y);
            if (storeDirection != move)
            {
                velocity = 0;
                storeDirection = move;
            }
            velocity += Time.deltaTime * acceleration;
            if (velocity >= 0.5f)
            {
                velocity = 0.5f;
            }
            //transform.Translate(move * velocity);
            transform.Translate(move * Time.deltaTime);
        }
        else
        {
            velocity -= Time.deltaTime * acceleration;
            if (velocity <= 0)
            {
                velocity = 0;
            }
        }
        //if (!isMain)
        //{
        //    handleMovementSideCharacter();
        //}
    }

    void handleMovementSideCharacter()
    {
        velocity = Time.deltaTime * acceleration;
        Vector3 move = new Vector3(0, 0, 1);
        transform.Translate(move * Time.deltaTime);
    }

    void changeVelocity()
    {


    }
    void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    void OnDisable()
    {
        input.CharacterControls.Disable();
    }
}
