using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoRotacion : MonoBehaviour
{
    private Player player;
    public float speedRotation;

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = player.transform.position - transform.position;
        Quaternion.RotateTowards(transform.rotation, player.transform.rotation, 60f);
        //rotation.x = 0;
        //rotation.y = 0;
        //transform.rotation = rotation;
    }
}
