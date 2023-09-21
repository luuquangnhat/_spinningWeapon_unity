using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterMoving : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;

    // variable to store the instance of the PlayerInput
    PlayerInput input;

    // variable to store player input values
    Vector2 currentMovement;
    bool movementPressed;

    void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Movement.performed += ctx =>
        {
            //Debug.Log($"ctx {ctx}");
            movementPressed = ctx.ReadValueAsButton();
        };
    }


    // Start is called before the first frame update
    void Start()
    {
        // set the animator reference
        animator = GetComponent<Animator>();

        // set the ID references
        isWalkingHash = Animator.StringToHash("isWalking");

        // test
        //Vector3 positionToLookAt = new Vector3(1, 0, 1);
        //transform.LookAt(positionToLookAt);
        //transform.LookAt(positionToLookAt);
        //Debug.Log($"currentMovement.x {currentMovement.x}");
    }

    public float speed = 10f;
    Vector3 move;
    // Update is called once per frame
    void Update()
    {
        handleMovement();
        //handleRotation();
        //move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //transform.Translate(move * speed * Time.deltaTime);
    }

    void handleRotation()
    {
        // Current position of our character
        Vector3 currentPosition = transform.position;

        // the change in position our character should point to
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);

        Debug.Log($"currentMovement (x, y): ({currentMovement.x}, {currentMovement.y}) ");

        // combine the position to give a position to look at
        Vector3 positionToLookAt = currentPosition + newPosition;

        // rotate the character to face the positionToLookAt
        transform.LookAt(positionToLookAt);
    }

    void handleMovement()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if (movementPressed)
        {
            animator.SetBool(isWalkingHash, true);

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            move = new Vector3(horizontal, 0, vertical);
            transform.Translate(move * speed * Time.deltaTime);
        }
        if (!movementPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
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
