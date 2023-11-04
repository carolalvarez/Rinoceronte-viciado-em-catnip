using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Bullet : MonoBehaviour
{
    Vector3 mousePos;
    public GameObject player;
    Vector2 bulletDir = Vector2.zero;
    Vector2 direction = Vector2.zero;
    Rigidbody2D rb;
    GameManager gameManager;
    [SerializeField]
    float velocity = 0;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            gameManager.PullManager(gameObject);
        }
        //transform.position = player.transform.position;
        //transform.GetComponent<Rigidbody2D>().velocity *= direction.normalized * 10;/*AddForce(, ForceMode2D.Impulse);*/
    }

   public void Movement()
    {
        bulletDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.parent.position);
        //bulletDir = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        direction = (bulletDir - (Vector2)transform.parent.position).normalized;
        rb.AddForce(direction * velocity, ForceMode2D.Impulse);
    }

}
