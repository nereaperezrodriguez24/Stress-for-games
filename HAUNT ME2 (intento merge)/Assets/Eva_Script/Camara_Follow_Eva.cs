using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Follow_Eva : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody Camara;
    public Transform Capsula;

    public Vector3 offset;

    public float cameraSpeed = 10f;


    public bool puedo_usar_inputs;

    public float gravity;

    public float speed;

 
    


    void Start()
    {
        Camara = GetComponent<Rigidbody>();

        puedo_usar_inputs = true;
    }

    // Update is called once per frame
    void Update()
    {
        Camara.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * gravity, ForceMode.Force);

        if (puedo_usar_inputs == true)
        {
            DetectarInputs();
        }

    
    }





    void DetectarInputs()
    {
        transform.position = Capsula.position + offset;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Camara.AddForce(new Vector3(35.0f, 0.0f, 0.0f) * speed);
        }


    }
}


/*Vector3 pos;
public float offset = 3f;


void Update()
{
    pos = Input.mousePosition;
    pos.z = offset;
    transform.position = Camera.main.ScreenToWorldPoint(pos);
}*/
