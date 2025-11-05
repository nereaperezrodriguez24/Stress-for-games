using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LogoVideo : MonoBehaviour
{
    public string Inicio = "MainMenu";
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
}
