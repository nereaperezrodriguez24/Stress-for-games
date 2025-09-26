using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saraprueba : MonoBehaviour
{
    // Sara
    
    private CharacterController characterController;
    private float ySpeed;
    private float OriginalStepOffSet;

    [Header("Player Settings")]
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;

    [Header("CameraFollow")]
    public Transform CameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        OriginalStepOffSet = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//Detect horizontal inputs like a d <- ->
        float verticalInput = Input.GetAxis("Vertical");//Detect vertical inputs like w s up and down arrows

        Vector3 movementDirection = new Vector3 (horizontalInput, 0.0f, verticalInput);
        float magnitude = Mathf.Clamp01 (movementDirection.magnitude) * speed; //The magnitude is never going to be infinity. It's limits are 1 or 0

        movementDirection = Quaternion.AngleAxis(CameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize(); //Allways the same velocity

        ySpeed += Physics.gravity.y * Time.deltaTime; //gravity in y

        if (characterController.isGrounded) //is on ground?
        {
            characterController.stepOffset = OriginalStepOffSet;
            ySpeed = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ySpeed = jumpSpeed;
            }
        }
        else //not climbing walls
        {
            characterController.stepOffset = 0.0f;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime); //Move player in direction

        if (movementDirection != Vector3.zero ) //chaeck if we are moving
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up); //create the rotate in direction of movement

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);//rotate
        }
    }
    private void OnApplicationFocus(bool focus) 
    {
        //Camera focus
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}