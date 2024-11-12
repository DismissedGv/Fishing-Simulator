// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovementScript : MonoBehaviour
// {
//     [SerializeField] private InputManager inputManager;
//     [SerializeField] private float speed;
//     [SerializeField] private Vector3 moveValue;
//     void Start()
//     {
//         if (inputManager != null)
//         {
//             inputManager.MovementEvent += OnMovement;
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         Vector3 movement = new Vector3() + moveValue;
//         transform.Translate(movement * Time.deltaTime * speed);
//     }
//     private void OnMovement(Vector3 value)
//     {
//         moveValue = value;
//     }
// }
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    public float moveSpeed = 5f; // Maximum movement speed
    public float acceleration = 10f; // Acceleration rate
    public float deceleration = 10f; // Deceleration rate

    private Vector2 moveInput; // Stores the movement input
    private Vector3 velocity; // Current velocity of the player
    void Start()
    {
        if (inputManager != null)
        {
            inputManager.MovementEvent += OnMovement;
        }
    }


    private void Update()
    {
        print(moveInput);
        // Target velocity based on input
        Vector2 targetVelocity = new Vector2(moveInput.x, moveInput.y) * moveSpeed;

        // Smoothly update velocity towards target velocity using acceleration/deceleration
        if (moveInput != Vector2.zero)
        {
            // Accelerate towards the target velocity
            velocity = Vector2.MoveTowards(velocity, targetVelocity, acceleration * Time.deltaTime);
        }
        else
        {
            // Decelerate to a stop when no input is present
            velocity = Vector2.MoveTowards(velocity, Vector3.zero, deceleration * Time.deltaTime);
        }

        // Apply velocity to the transform's position
        transform.Translate(velocity * Time.deltaTime, Space.World);
    }

    // This function is automatically called by the Input System when input is detected

    private void OnMovement(Vector2 value)
    {
        moveInput = value;
    }
}