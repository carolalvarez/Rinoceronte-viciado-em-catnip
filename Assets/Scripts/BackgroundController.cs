using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    float time1 = 0,time2 = 0,time3 = 0;
    [SerializeField]
    GameObject building;
    [SerializeField]
    GameObject sky;
    [SerializeField]
    GameObject Ground;
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    float spawnTimerBuildings;
    [SerializeField]
    float spawnTimerSky;
    [SerializeField]
    float spawnTimerGround;

    // Update is called once per frame
    void Update()
    {
        time1 += Time.deltaTime; 
        if(time1 > spawnTimerBuildings)
        {
            Instantiate(building, spawnPoint);
            time1 = 0;
        }
        time2 += Time.deltaTime; 
        if(time2 > spawnTimerSky)
        {
            Instantiate(sky, spawnPoint);
            time2 = 0;
        }
        time3 += Time.deltaTime; 
        if(time3 > spawnTimerGround)
        {
            Instantiate(Ground, spawnPoint);
            time3 = 0;
        }

    }
}
