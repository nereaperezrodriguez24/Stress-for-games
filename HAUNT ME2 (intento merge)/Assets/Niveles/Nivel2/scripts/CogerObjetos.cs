using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjetos : MonoBehaviour
{
    //Nerea

    public GameObject handPoint;

    private GameObject pickedObject = null;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // quitar objeto con j
       /* if (pickedObject != null)
        {
            if (Input.GetKey("j"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                pickedObject = null;
            }
        }*/

        if (pickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.transform.SetParent(null);
                pickedObject = null;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        //coger objeto con k

        if (other.gameObject.CompareTag("objeto"))
        {
            if (Input.GetKeyDown(KeyCode.K) && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = handPoint.transform.position;
                other.transform.SetParent(handPoint.transform);

                pickedObject = other.gameObject;
            }
        }


    }

}
