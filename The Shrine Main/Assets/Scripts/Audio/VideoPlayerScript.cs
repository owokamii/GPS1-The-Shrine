using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    public VideoPlayer _videoPlayer;
    public VideoClip _video1;
    public VideoClip _video2;

    public float timeTaken1;
    public float timeTaken2;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        Invoke("PlayVideo1", timeTaken1);
        Invoke("PlayVideo2", timeTaken2);
    }

    // Update is called once per frame
    public void PlayVideo1()
    {
        _videoPlayer.playbackSpeed = 0.75f;
        _videoPlayer.clip = _video1;
        _videoPlayer.Play();
    }

    public void PlayVideo2()
    {
        _videoPlayer.playbackSpeed = 1f;
        _videoPlayer.clip = _video2;
        _videoPlayer.Play();
    }
}
