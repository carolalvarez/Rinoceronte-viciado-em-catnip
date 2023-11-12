using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MenuFinalCongreso : MonoBehaviour
{
    [SerializeField]
    VideoPlayer video;

    // Start is called before the first frame update
    void Start()
    {
        video = gameObject.GetComponent<VideoPlayer>();
        video.loopPointReached += EndReached;
    }

    // Método llamado cuando el video llega al final
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Cambiar a la escena deseada
        SceneManager.LoadScene(0);
    }
}
