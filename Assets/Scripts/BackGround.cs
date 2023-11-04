using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    float backgroundSpeed = 0;
    [SerializeField]
    Transform destroyPoint;
    void Start()
    {
    }

    void Update()
    {
        transform.position += new Vector3(backgroundSpeed * Time.deltaTime,0,0);

        if (transform.position.x <= -23.1900005)
        {
            Destroy(this.gameObject);
        }
    }
}
