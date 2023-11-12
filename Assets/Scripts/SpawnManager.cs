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
    float spawnTankTimeMax; 
    [SerializeField]
    float spawnTankTimeMin;
    [SerializeField]
    float spawnHelicopterTimeMax;
    [SerializeField]
    float spawnHelicopterTimeMin;
    [SerializeField]
    Transform spawnpointTank, spawnPointHelicopter;
    TimeManager timeMan;
    float time1_, time2_;

    float time1, time2;
    void Start()
    {
        time1 = Random.Range(spawnTankTimeMin, spawnTankTimeMax);
        time2 = Random.Range(spawnHelicopterTimeMin, spawnHelicopterTimeMax); 
        timeMan = FindObjectOfType<TimeManager>();
    }
    void Update()
    {
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
        
        if(time1 > time1_)
        {
            Instantiate(tankPref,spawnpointTank.position,Quaternion.identity);
            time1_ = Random.Range(spawnTankTimeMin, spawnTankTimeMax);
            time1 = 0;
        }

        if (time2 > time2_)
        {
            Instantiate(helicopterPref, spawnPointHelicopter.position, Quaternion.identity);
            time2_ = Random.Range(spawnHelicopterTimeMin, spawnHelicopterTimeMax);
            time2 = 0;
        }
    }
}
