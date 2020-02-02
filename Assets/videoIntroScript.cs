using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoIntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");

        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
