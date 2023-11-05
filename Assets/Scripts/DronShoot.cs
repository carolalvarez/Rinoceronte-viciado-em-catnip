using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronShoot : MonoBehaviour
{
    [SerializeField] float shootTimer;
    float shootRef;
    [SerializeField] GameObject bullet;
    void Start()
    {
        shootRef = shootTimer;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer-=Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = shootRef;
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
