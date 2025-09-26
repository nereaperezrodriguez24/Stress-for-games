// This first example shows how to move using Input System Package (New)

using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class Example : MonoBehaviour
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

        controller = gameObject.AddComponent<CharacterController>();

        mapeo.Player.Movement.performed += movement_data =>
        {
            input_data = movement_data.ReadValue <Vector2>();
            Debug.Log("perfomed: " + input_data);
        };
        mapeo.Player.Movement.canceled += context =>
        {
            input_data = context.ReadValue<Vector2>();
            Debug.Log("cancel: " + input_data);
        };

        
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
