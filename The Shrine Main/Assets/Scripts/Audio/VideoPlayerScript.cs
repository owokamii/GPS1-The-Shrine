using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    public VideoPlayer _videoPlayer;
    public VideoClip _video1;
    public VideoClip _video2;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        Invoke("PlayVideo1", 7f);
        Invoke("PlayVideo2", 23.6f);
    }

    // Update is called once per frame
    public void PlayVideo1()
    {
        _videoPlayer.clip = _video1;
        _videoPlayer.Play();
    }

    public void PlayVideo2()
    {
        _videoPlayer.clip = _video2;
        _videoPlayer.Play();
    }
}
