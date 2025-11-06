using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementInputTest : MonoBehaviour
{
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 input_data;

    private InputMapTest mapeo;


    private void Awake()
    {

        mapeo = new InputMapTest();

        input_data = Vector2.zero;

        mapeo.Player.Movement.performed += patata =>
        {
            input_data = patata.ReadValue<Vector2>();
            Debug.Log("Performed: " + input_data);
        };

       

        mapeo.Player.Movement.canceled += patata =>
        {
            input_data = patata.ReadValue<Vector2>();
            Debug.Log("Canceled: " + input_data);
        };

        controller = gameObject.AddComponent<CharacterController>();
    }

    private void OnEnable()
    {
        mapeo.Enable();
    }

    private void OnDisable()
    {
        mapeo.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Read input
       
        Vector3 move = new Vector3(input_data.x, 0.0f, input_data.y);
        move = Vector3.ClampMagnitude(move, 1.0f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Jump
        

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
}
