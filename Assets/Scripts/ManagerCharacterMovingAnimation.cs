using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerCharacterMovingAnimation : MonoBehaviour
{
    Animator animator;
    public float velocityZ = 0.0f;
    public float velocityX = 0.0f;
    public float acceleration = 2f;
    public float deceleration = 0.2f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    public PlayerInput input;
    // increase performance
    int VelocityZHash;
    int VelocityXHash;
    Vector2 direction;
    bool runPressed;

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
                input.CharacterControls.Movement.performed += (ctx) =>
                {
                    //Debug.Log($"ManagerCharacterMovingAnimation - ctx {ctx}");
                    onMovement(ctx);
                };
                input.CharacterControls.Movement.canceled += onMovement;
                input.CharacterControls.Run.performed += onRunning;
                input.CharacterControls.Run.canceled += onRunning;
            }
            else
            {
                input.CharacterControls.Movement.performed -= (ctx) =>
                {
                    //Debug.Log($"ManagerCharacterMovingAnimation - ctx {ctx}");
                    onMovement(ctx);
                };
                input.CharacterControls.Movement.canceled -= onMovement;
                input.CharacterControls.Run.performed -= onRunning;
                input.CharacterControls.Run.canceled -= onRunning;
            }
        }
    }



    private void Awake()
    {
        input = new PlayerInput();
    }

    void onMovement(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }
    void onRunning(InputAction.CallbackContext ctx)
    {
        runPressed = ctx.ReadValue<bool>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityZHash = Animator.StringToHash("VelocityZ");
        VelocityXHash = Animator.StringToHash("VelocityX");
    }

    // handles acceleration and deceleration
    void handleTurnRight()
    {
        velocityX += Time.deltaTime * acceleration;
    }
    void handleTurnBackward()
    {
        velocityZ -= Time.deltaTime * acceleration;
    }
    void handleTurnLeft()
    {
        velocityX -= Time.deltaTime * acceleration;
    }
    void handleTurnForward()
    {
        velocityZ += Time.deltaTime * acceleration;
    }

    void changeVelocity()
    {
        if (direction != Vector2.zero && isMain)
        {
            float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;
            // if player press backward
            if (velocityZ > -currentMaxVelocity && direction == -Vector2.up)
            {
                handleTurnBackward();
            }
            // if player press forward
            if (velocityZ < currentMaxVelocity && direction == Vector2.up)
            {
                handleTurnForward();
            }
            // increase velocity in left direction
            if (velocityX > -currentMaxVelocity && direction == Vector2.left)
            {
                handleTurnLeft();
            }
            // increase velocity in right direction
            if (velocityX < currentMaxVelocity && direction == Vector2.right)
            {
                handleTurnRight();
            }
        }
        else
        {
            // decrease velocityZ - backward
            if (velocityZ < 0.0f)
            {
                velocityZ += Time.deltaTime * deceleration;
            }
            // decrease velocityZ - forward
            if (velocityZ > 0.0f)
            {
                velocityZ -= Time.deltaTime * deceleration;
            }
            // increase velocityX if left is not pressed and velocityX < 0
            if (velocityX < 0.0f)
            {
                velocityX += Time.deltaTime * deceleration;
            }
            // decrease velocityX if left is not pressed and velocityX > 0
            if (velocityX > 0.0f)
            {
                velocityX -= Time.deltaTime * deceleration;
            }
        }
    }

    void changeVelocitySideCharacter()
    {
        velocityX = 0f;
        Debug.Log($"velocityZ {velocityZ}");
        if (velocityZ < 0.5f)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
    }

    void lockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backwardPressed, bool runPressed, float currentMaxVelocity)
    {
        // reset velocityZ
        //if (!forwardPressed && velocityZ < 0.0f)
        if (!backwardPressed && !forwardPressed && velocityZ != 0.0f && (velocityZ > -0.05f && velocityZ < 0.05f))
        {
            velocityZ = 0.0f;
        }
        // reset velocityX
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }

        // locking backward
        if (backwardPressed && runPressed && velocityZ < -currentMaxVelocity)
        {
            velocityZ = -currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (backwardPressed && velocityZ < -currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * deceleration;
            // round to the currentMaxVelocity if within offset
            if (velocityZ < -currentMaxVelocity && velocityZ > (-currentMaxVelocity - 0.05f))
            {
                velocityZ = -currentMaxVelocity;
            }
        }
        else if (backwardPressed && velocityZ > -currentMaxVelocity && velocityZ < (-currentMaxVelocity + 0.05f))
        {
            velocityZ = -currentMaxVelocity;
        }


        // locking forward
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            // round to the currentMaxVelocity if within offset
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

        // locking left
        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            // round to the currentMaxVelocity if within offset
            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        // round to the currentMaxVelocity if within offset
        else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
        {
            velocityX = -currentMaxVelocity;
        }

        // locking right
        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            // round to the currentMaxVelocity if within offset
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        // round to the currentMaxVelocity if within offset
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        changeVelocity();
        //lockOrResetVelocity(forwardPressed, leftPressed, rightPressed, backwardPressed, runPressed);
        //Debug.Log($"velocityZ {velocityZ} - velocityX {velocityX}");
        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);
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
