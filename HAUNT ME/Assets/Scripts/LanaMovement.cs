using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LanaMovement : MonoBehaviour
{
    // Sara

    private CharacterController characterController;
    private float ySpeed;
    private float OriginalStepOffSet;
    public LanaTransform LanaTransform;//public antes
    public float timer = 3.0f;

    [Header("Player Settings")]
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;
    public Vector3 savePosition;
    private quaternion saveRotation;
    public bool isTeleporting = false;
    

    [Header("CameraFollow")]
    public Transform CameraTransform;

    [Header("Transformations")]
    public bool Lana = false;
    //private Transform PlayerPosition;
    public PlayerManager PlayerManager;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        OriginalStepOffSet = characterController.stepOffset;
        PlayerManager.CanUseInputs = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (LanaTransform.isLana == true)
        {
            Lana = true;
            CameraTransform.transform.position = LanaTransform.PointOfView.transform.position;
            
            Movement();
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                Fantasma();
            }
        }
    }
    public void SaveLanaPosition()
    {
        savePosition = LanaTransform.PointOfView.position;
        saveRotation = LanaTransform.PointOfView.rotation;
        Debug.Log("savePosition actual: " + savePosition);
    }
    public void Fantasma()//Bloquear inputs al destransformarse
    {
        if (Lana == true && Input.GetKeyDown(KeyCode.E))
        {
            PlayerManager.CanUseInputs = false;
            SaveLanaPosition();
            isTeleporting = true;

            // 1. Cambiar cámaras
            LanaTransform.LanaCamera.SetActive(false);
            LanaTransform.PlayerCamera.SetActive(true);
            LanaTransform.PointOfView.SetParent(LanaTransform.transform);

            LanaTransform.PointOfView.localPosition = Vector3.zero;
            LanaTransform.PointOfView.localRotation = Quaternion.identity;
            // 2. Obtener componentes del player
            Transform playerRoot = LanaTransform.PlayerCamera.transform.root;

            // 3. Aplicar rotación y posición
            playerRoot.position = savePosition;
            playerRoot.rotation = saveRotation;

            // 4. Cambiar skins
            LanaTransform.LanaSkin.SetActive(false);
            LanaTransform.PlayerSkin.SetActive(true);

            // 5. Cambiar estados
            Lana = false;
            LanaTransform.isLana = false;

            // 6. Desactivar este script
            if (this.enabled) this.enabled = false;

            Debug.Log("? Teletransportado a: " + savePosition);
            if(playerRoot.position == savePosition)
            {
                PlayerManager.CanUseInputs = true;
            }
        }
    }


    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//Detect horizontal inputs like a d <- ->
        float verticalInput = Input.GetAxis("Vertical");//Detect vertical inputs like w s up and down arrows

        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed; //The magnitude is never going to be infinity. It's limits are 1 or 0

        movementDirection = Quaternion.AngleAxis(CameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize(); //Allways the same velocity

        ySpeed += Physics.gravity.y * Time.deltaTime; //gravity in y

        if (characterController.isGrounded) //is on ground?
        {
            characterController.stepOffset = OriginalStepOffSet;
            ySpeed = -0.15f;
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

        if (movementDirection != Vector3.zero) //chaeck if we are moving
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up); //create the rotate in direction of movement

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);//rotate
        }
    }

}
