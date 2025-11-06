using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eva_Prueba_Script : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody Capsula;
    public float speed;

    public bool puedo_usar_inputs;

    public float gravity;

    void Start()
    {
        Capsula = GetComponent<Rigidbody>();
        puedo_usar_inputs = true;


        Capsula.constraints =
               RigidbodyConstraints.FreezeRotationX
               | RigidbodyConstraints.FreezeRotationY;


    }

    // Update is called once per frame
    void Update()
    {

        Capsula.constraints = RigidbodyConstraints.FreezeRotation;
             
        Capsula.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * gravity, ForceMode.Force);

        if (puedo_usar_inputs == true)
        {
            DetectarInputs();
        }


    }

    void DetectarInputs()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            Capsula.AddForce(new Vector3(35.0f, 0.0f, 0.0f) * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Capsula.velocity = Vector3.zero;
            Capsula.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * gravity, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            
            Capsula.AddForce(new Vector3(-35.0f, 0.0f, 0.0f) * speed);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            Capsula.AddForce(new Vector3(0.0f, 0.0f, 35.0f) * speed);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            Capsula.AddForce(new Vector3(0.0f, 0.0f, -35.0f) * speed);
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("He detectado una colisión con: " + collision.gameObject.name);

        if (collision.gameObject.tag == "muerte")
        {
            
            Debug.Log("He detectado una colisión con Muerte");
            puedo_usar_inputs = false;



        }


    }




}