using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    public VideoPlayer _videoPlayer;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        Invoke("playVideo", 6f);
    }

    // Update is called once per frame
    public void playVideo()
    {
        _videoPlayer.Play();
    }
}
