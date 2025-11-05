using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Rendering.DebugUI;

public class MenuManager : MonoBehaviour
{

    public bool settingActive;
    public GameObject MenuSettings;
    public bool puedo_usar_inputs;
    // Start is called before the first frame update
    void Start()
    {
        puedo_usar_inputs = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puedo_usar_inputs == true)
        {
            Inputs();
        }
    }
    public void Restart()

    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MenuSettings.activeInHierarchy)
            {
                MenuSettings.SetActive(true);


                Time.timeScale = 0.0f;

               

            }



            else
            {
                MenuSettings.SetActive(false);


                Time.timeScale = 1.0f;

            }

        }
    }

    public void Rules()

    {
        SceneManager.LoadScene(5);
    }

    /*public void Nivel2()

    {
        SceneManager.LoadScene(2);
    }*/

    public void ExitGame()
    {
        Application.Quit();

        EditorApplication.Exit(0);
    }

    public void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Debug.Log("Activo");
            if (!MenuSettings.activeInHierarchy)
            {
                MenuSettings.SetActive(true);
            }
              else
            {
                MenuSettings.SetActive(false);
            }

        }
      
    }
}