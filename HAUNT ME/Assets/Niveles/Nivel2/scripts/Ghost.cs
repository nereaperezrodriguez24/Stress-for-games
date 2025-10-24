using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Nerea

    private CharacterController characterController2;
    private float ySpeed2;
    private float OriginalStepOffSet2;

    [Header("Player Settings")]
    public float speed2;
    public float jumpSpeed2;
    public float rotationSpeed2;

    [Header("CameraFollow")]
    public Transform CameraTransform2;


    //private Transform PlayerPosition;


    // Start is called before the first frame update
    void Start()
    {
        characterController2 = GetComponent<CharacterController>();
        OriginalStepOffSet2 = characterController2.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//Detect horizontal inputs like a d <- ->
        float verticalInput = Input.GetAxis("Vertical");//Detect vertical inputs like w s up and down arrows

        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed2; //The magnitude is never going to be infinity. It's limits are 1 or 0

        movementDirection = Quaternion.AngleAxis(CameraTransform2.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize(); //Allways the same velocity

        ySpeed2 += Physics.gravity.y * Time.deltaTime; //gravity in y

        if (characterController2.isGrounded) //is on ground?
        {
            characterController2.stepOffset = OriginalStepOffSet2;
            ySpeed2 = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ySpeed2 = jumpSpeed2;
            }
        }
        else //not climbing walls
        {
            characterController2.stepOffset = 0.0f;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed2;
        characterController2.Move(velocity * Time.deltaTime); //Move player in direction

        if (movementDirection != Vector3.zero) //chaeck if we are moving
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up); //create the rotate in direction of movement

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed2 * Time.deltaTime);//rotate
        }

    }
}
