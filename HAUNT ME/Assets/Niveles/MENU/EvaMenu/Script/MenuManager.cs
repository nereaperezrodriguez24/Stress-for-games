using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restart()

    {
        SceneManager.LoadScene(3);
    }

    public void Rules()

    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Application.Quit();

        EditorApplication.Exit(0);
    }
}