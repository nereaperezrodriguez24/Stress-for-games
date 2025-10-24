using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class LanaTransform : MonoBehaviour
{
    public GameObject LanaSkin;// Prefab o modelo al que quieres transformarte
    public GameObject PlayerSkin;
    public bool isLana = false;
    public GameObject LanaCamera;
    public GameObject PlayerCamera;
    //private PlayerManager playerManager;
    public Transform PointOfView;
    
    void Start()
    {
        PlayerSkin = GetComponentInChildren<MeshRenderer>().gameObject;
        LanaCamera.SetActive(false);
        PlayerCamera.SetActive(true);
    }
    void Update()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Lana") && Input.GetKeyDown(KeyCode.E) && isLana == false) // cuando el jugador toca este objeto
        {

            PlayerCamera.SetActive(false);
            LanaCamera.SetActive(true);
            
            PointOfView.SetParent(LanaSkin.transform);
            PointOfView.localPosition = Vector3.zero;
            
            Debug.Log("Colisión detectada con Lana");
            
            // Se desactiva la forma del jugador
            
            if (PlayerSkin != null)
            {
                Debug.Log("false");
                PlayerSkin.SetActive(false);
            }

            // se tdransforma en lana
            LanaSkin.SetActive(true);
            
            isLana = true;
            Debug.Log("Active");
        }
       
    }
}