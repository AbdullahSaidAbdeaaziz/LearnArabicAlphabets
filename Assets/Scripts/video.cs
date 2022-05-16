using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    public VideoPlayer vp;
    private void Start()
    {
        vp.loopPointReached += OnVideoEnded;
    }

    private void OnVideoEnded(VideoPlayer videoPlayer)
    {
        videoPlayer.Stop();
        Switch.playGame(2);
    }
}
