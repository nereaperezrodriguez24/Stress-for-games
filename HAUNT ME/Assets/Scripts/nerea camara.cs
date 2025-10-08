using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nereacamara : MonoBehaviour
{
    public Transform player;

    public float speed = 10.0f;

    public Vector3 offset;

    public float arriba;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.z, transform.position.y);
        //arriba = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        // camara.constraints = RigidbodyConstraints.FreezePositionY ;

        Vector3 targetPosition = player.position + offset;


        targetPosition.y = arriba;

        transform.position = targetPosition;
    }
}
