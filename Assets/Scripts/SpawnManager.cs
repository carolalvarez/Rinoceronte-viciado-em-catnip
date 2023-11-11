using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject tankPref;
    [SerializeField]
    GameObject helicopterPref;
    [SerializeField]
    float spawnTankTime;
    [SerializeField]
    float spawnHelicopterTime;
    [SerializeField]
    Transform spawnpointTank, spawnPointHelicopter;
    TimeManager timeMan;

    float time1, time2;
    void Start()
    {
        time1 = 0;
        time2 = 0;
        timeMan = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
        
        if(time1 > spawnTankTime)
        {
            Instantiate(tankPref,spawnpointTank.position,Quaternion.identity);
            time1 = 0;
        }

        if (time2 > spawnHelicopterTime)
        {
            Instantiate(helicopterPref, spawnPointHelicopter.position, Quaternion.identity);
            time2 = 0;
        }
    }
}
