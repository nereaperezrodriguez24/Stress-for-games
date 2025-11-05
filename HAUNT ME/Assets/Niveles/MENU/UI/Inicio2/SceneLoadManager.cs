using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private Slider Loadbar;
    [SerializeField] private GameObject LoadPanel;

    public float timer = 3.0f;

   
    public void SceneLoad(int sceneIndex)
    {
        LoadPanel.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
            //LoadAsync();
        }
    }

    IEnumerator LoadAsync(int sceneIndex)
{
    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

   
    asyncOperation.allowSceneActivation = false;

    while (!asyncOperation.isDone)
    {
        float progress = Mathf.Clamp01(asyncOperation.progress / 0.01f);
        Loadbar.value = progress;

        Debug.Log("Progreso: " + progress);

       
        if (asyncOperation.progress >= 0.01f)
        {
          
            asyncOperation.allowSceneActivation = true;
        }

        yield return null;
    }
}

}

