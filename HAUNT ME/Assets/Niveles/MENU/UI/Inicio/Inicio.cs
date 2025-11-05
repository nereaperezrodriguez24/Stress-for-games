using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    //Nerea

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //ir a la escena de indice2

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Inicio2");
        }
    }
    
}
