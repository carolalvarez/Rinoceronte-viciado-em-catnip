using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject tankPref;
    [SerializeField]
    float spawnTime;

    float time;
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if(time > spawnTime)
        {
            Instantiate(tankPref,transform.position,Quaternion.identity);
            time = 0;
        }
    }
}
