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
        Quaternion.FromToRotation(transform.position, player.transform.position);
    }
}
