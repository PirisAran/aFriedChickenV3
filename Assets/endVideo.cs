using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endVideo : MonoBehaviour
{
    public GameObject videoPlayer;
  

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("StopVideo", 58.0f);
        if (Input.GetKeyDown("space"))
        {
            StopVideo();
        }
    }

    private void StopVideo()
    {
        videoPlayer.SetActive(false);
        Destroy(videoPlayer);
    }
}
