using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class LanaTransform : MonoBehaviour
{
    public GameObject LanaSkin; // Prefab o modelo al que quieres transformarte
    public GameObject PlayerSkin;
    public bool isLana = false;
    public GameObject LanaCamera;
    public GameObject PlayerCamera;
    
    void Start()
    {
        PlayerSkin = GetComponentInChildren<MeshRenderer>().gameObject;
        LanaCamera.SetActive(false);
        PlayerCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Lana") && Input.GetKeyDown(KeyCode.E) && isLana == false) // cuando el jugador toca este objeto
        {
            PlayerCamera.SetActive(false);
            LanaCamera.SetActive(true);
            Debug.Log("Colisión detectada con Lana");

            Transform playerTransform = hit.collider.transform;
            
            // Se desactiva la forma del jugador

            if (PlayerSkin != null)
            {
                Debug.Log("Active");
                PlayerSkin.SetActive(false);
            }

            // se tdransforma en lana
            PlayerSkin = Instantiate(LanaSkin, transform);
            LanaSkin.SetActive(true);
            // Ajustamos posición relativa (para que aparezca en el centro del jugador)
            /*PlayerSkin.transform.localPosition = Vector3.zero;
            PlayerSkin.transform.localRotation = Quaternion.identity;*/
            isLana = true;
            Debug.Log("Active");
        }
        /*
         if (isLana == true && Input.GetKeyDown(KeyCode.E))
         {
                // Volver al skin original
                PlayerSkin.SetActive(true);
                LanaSkin.SetActive(false);
                isLana = false;
         }
        else
        {
            // Transformarse en Lana
            PlayerSkin.SetActive(false);
            LanaSkin.SetActive(true);
            isLana = true;
        }*/
    }
}