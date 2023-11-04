using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    float backgroundSpeed = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(transform.position.x * backgroundSpeed * Time.deltaTime,0,0);
    }
}
