using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_Ne_InputTest_E : MonoBehaviour
{
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 input_data;

    private InputMapTest_E mapeo;

    private void Awake()
    {

        mapeo = new InputMapTest_E();


        mapeo.Player_E.Movement.performed += patata =>
        {
            input_data = patata.ReadValue<Vector2>();
            Debug.Log("Input performed: " + input_data);  

        };

        mapeo.Player_E.Movement.canceled += patata =>
        {
            input_data = patata.ReadValue<Vector2>();
            Debug.Log("Input canceled: " + input_data);

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
        if (groundedPlayer && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = 0.0f;
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
