using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronBullet : MonoBehaviour
{
    GameObject Player;
    Vector2 direction;
    Rigidbody2D rb;
    [SerializeField] float speed;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Rino");
        direction = Player.transform.position - transform.position;
        transform.up = direction;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up*speed;
        timer += Time.deltaTime;
        if (timer > 5)
            Destroy(this.gameObject);
    }
}
