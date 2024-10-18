using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 moveValue;
    [SerializeField] private Rigidbody rb;
    void Start()
    {
        if (inputManager != null)
        {
            inputManager.MovementEvent += OnMovement;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 movement = new Vector3()+moveValue;
        transform.Translate(movement * Time.deltaTime * speed);
        Debug.Log(rb.velocity);
    }
    private void OnMovement(Vector3 value)
    {
        moveValue = value;
    }
}
