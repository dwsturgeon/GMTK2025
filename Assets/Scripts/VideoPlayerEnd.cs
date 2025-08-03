using UnityEngine;
using UnityEngine.Video; // Required for VideoPlayer
using UnityEngine.SceneManagement; // Example for scene loading

public class VideoFinishedDetector : MonoBehaviour
{
    public VideoPlayer videoPlayer;


    void OnEnable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnDisable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }

    void OnVideoFinished(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video has finished playing!");
        // Example: Load another scene
        SceneManager.LoadScene("Game");
    }
}