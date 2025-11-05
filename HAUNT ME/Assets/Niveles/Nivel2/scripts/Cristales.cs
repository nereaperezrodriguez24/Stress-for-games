using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Cristales : MonoBehaviour
{
    //Nerea
    // script para recoger cristales, contador, y que te permita atravesar la puerta

    public bool puedo_usar_imputs;

    //cristales
    public TMP_Text cristales;
    public int puntos_cristales;
    public GameObject cristal;
    public GameObject cristal2;
    public GameObject cristal3;

    //puerta
    public GameObject puerta;
    public bool abrir;

    // Start is called before the first frame update
    void Start()
    {
        puedo_usar_imputs = true;

        abrir = false;
    }

    // Update is called once per frame
    void Update()
    {
        cristales.text = "Cristales: " + puntos_cristales;

      

        
    }


    private void OnTriggerEnter(Collider other)
    {
        //cuando toque el cristal1, o el 2, o el 3
        if (other.CompareTag("cristal") || other.CompareTag("cristal2") || other.CompareTag("cristal3"))
        {
            //se añade un punto
            puntos_cristales++;
            //y se desactiva el objeto para que no se pueda a volver a uasr el mismo
            other.gameObject.SetActive(false);
            Debug.Log("He detectado un cristal. Total: " + puntos_cristales);
        }

        if ( (other.gameObject.CompareTag("puerta")) && puntos_cristales >= 3 )
        { 
            abrir = true;

            if (abrir == true)
            {
                SceneManager.LoadScene(0);
            }
        }

       
    }



   


}
