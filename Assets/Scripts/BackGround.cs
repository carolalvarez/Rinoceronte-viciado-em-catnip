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
        transform.position += new Vector3(backgroundSpeed * Time.deltaTime,0,0);

        if (transform.position.x <= -50)
        {
            Destroy(this.gameObject);
        }
    }
}
