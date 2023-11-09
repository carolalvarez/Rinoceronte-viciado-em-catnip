using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField]
    float tankSpeed;

    void Update()
    {
        transform.position += new Vector3(tankSpeed * Time.deltaTime, 0, 0);
    }
}
