using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField]VideoPlayer videoPlayer;

    [SerializeField] string videoFileName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        videoPlayer.url = videoPath;

        // Subscribe to the prepareCompleted event
        videoPlayer.prepareCompleted += OnVideoPrepared;

        // Prepare the video
        videoPlayer.Prepare();
        
    }



    void OnVideoPrepared(VideoPlayer source)
    {
        videoPlayer.Play();
    }

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
