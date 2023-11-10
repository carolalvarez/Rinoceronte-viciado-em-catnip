using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronShoot : MonoBehaviour
{
    [SerializeField] float shootTimer;
    float shootRef;
    [SerializeField] GameObject bullet;
    GameObject player;
    [SerializeField]
    float pos1, pos2;
    void Start()
    {
        shootRef = shootTimer;
        player = GameObject.Find("Rino");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.parent.position.x - pos1, transform.parent.position.y - pos2) ;

        Vector3 directionToPlayer = player.transform.position - transform.position;

        // Calcula el ángulo de rotación necesario para mirar al jugador
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Aplica la rotación al objeto Enemy
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        shootTimer -=Time.deltaTime;
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
