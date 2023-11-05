using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronBullet : MonoBehaviour
{
    GameObject Player;
    Vector2 direction;
    Rigidbody2D rb;
    [SerializeField] float speed;
    GameManager gameManager;
    float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager= FindObjectOfType<GameManager>();
        Player = gameManager.FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        timer-= Time.deltaTime;
        if (timer >= 0)
        {
            direction = Player.transform.position - transform.position;
            transform.up = direction;
        }
        rb.velocity = transform.up*speed;
    }
}
