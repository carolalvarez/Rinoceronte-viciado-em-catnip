using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    float time = 0;
    [SerializeField]
    GameObject background;
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    float spawnTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; 
        if(time > spawnTimer)
        {
            Instantiate(background, spawnPoint);
            time = 0;
        }

    }
}
