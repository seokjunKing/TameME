using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoCtrl : MonoBehaviour
{
    public VideoPlayer video;

    int num_Scene;
    private void Awake()
    {
        video.Play();
        num_Scene = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        if (video.frame > 0 && !video.isPlaying)
        {
            SceneManager.LoadScene(num_Scene + 1);
        }
    }
}