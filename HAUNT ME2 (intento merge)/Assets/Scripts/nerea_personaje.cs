using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class nerea_personaje : MonoBehaviour
{
    //player setting
    [Header("Player Settings")]
    public Rigidbody body;

    public float gravity;
    public float jump_force;
    public float moveiz;
    public float movede;
    public float movedown;

    public bool alive;
    public bool puedo_usar_imputs;

    //public Animator anim_controller;

    public bool resultados;
    // Start is called before the first frame update
    void Start()
    {
       

        //body = GetComponent<Rigidbody>();
        puedo_usar_imputs = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Time.timeScale == 1.0f)
        {
            body.AddForce(new Vector3(0.0f, -1.0f, 0.0f)* gravity, ForceMode.Force);
        }

        if (puedo_usar_imputs == true)
        {
            detectarimputs();
        }*/




        body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        body.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * gravity, ForceMode.Force);
        //  detectarimputs();

        if (puedo_usar_imputs == true)
        {
            detectarimputs();


        }
    }

    void detectarimputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
            if(salto)
            {
                salto.Play();
            }*/

            
            // body.velocity = Vector3.zero;

            //anim_controller.SetBool("moverse2", true);
            //anim_controller.SetBool("moverse3", false);

            body.AddForce(new Vector3(0.0F, 1.0F, 0.0F) * jump_force, ForceMode.VelocityChange);
            body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            
           // anim_controller.SetBool("moverse2", true);
            // anim_controller.SetBool("moverse3", true);

            body.AddForce(new Vector3(-1.0F, 0.0F, 0.0F) * moveiz, ForceMode.VelocityChange);
            body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            
           // anim_controller.SetBool("moverse2", true);
            // anim_controller.SetBool("moverse3", true);
            body.AddForce(new Vector3(1.0F, 0.0F, 0.0F) * movede, ForceMode.VelocityChange);
            body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //anim_controller.SetBool("moverse2", false);
            // anim_controller.SetBool("moverse2", false);
            body.AddForce(new Vector3(0.0F, -1.0F, 0.0F) * movede, ForceMode.VelocityChange);
            body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        }


        
    }
}
