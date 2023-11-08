using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    GameManager gameManager;
    GameObject bullet_;
    Rigidbody2D rb;

    float timer = 0;
    float timer2 = 0;

    [Header("Disparo")]
    [SerializeField]
    float cadencia;
    [SerializeField]
    float cooldownCadencia;
    [SerializeField]
    float topeCadencia;
    [SerializeField]
    float sumaCadencia = 0;
    [SerializeField]
    float timeShoting = 0;
    [SerializeField]
    float holdMouseTime;
    float cadenciaRef;
    float bulletTime = 0;
    [SerializeField]
    float totalBulletTime = 0;
    [SerializeField]
    Slider CadenciaBarr;
    [SerializeField]
    bool canShot;


    [Header("Jump")]
    [SerializeField]
    float jumpForce = 0;
    bool ground;
    float jumpTime= 0;
    float jumpForceRef;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        cadenciaRef = cadencia;
        CadenciaBarr.maxValue = timeShoting;
        canShot = true;
        jumpForceRef = jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        CadenciaBarr.value = totalBulletTime; // actualizacion de la barra del UI

        if (Input.GetKey(KeyCode.Space))
        {
            if(jumpTime < 1)
            {
                jumpTime += Time.deltaTime;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            jumpForce *= jumpTime;

            if (ground)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpTime = 0;
                jumpForce = jumpForceRef;
            }
            
        }


        if (Input.GetMouseButton(0))
        {
            if (canShot)
            {
                timer += Time.deltaTime;
                totalBulletTime += Time.deltaTime;
                if (timer >= cooldownCadencia)
                {
                    if (cadencia <= topeCadencia)
                        cadencia = topeCadencia;
                    else
                        cadencia -= sumaCadencia;

                    timer = 0;
                }
                bulletTime += Time.deltaTime;
                if (bulletTime > cadencia)
                {
                    if (gameManager.pull.Count != 0)
                    {
                        bullet_ = gameManager.pull[0];
                        gameManager.ActiveBullet();
                        bullet_.transform.position = new Vector3(transform.GetChild(0).position.x + Random.Range(-0.5f, 0.5f), transform.GetChild(0).position.y + Random.Range(-0.5f, 0.5f), 0);
                        bullet_.GetComponent<Bullet>().Movement();
                    }
                    else
                    {
                        bullet_ = Instantiate(bulletPrefab, new Vector3(transform.GetChild(0).position.x + Random.Range(-0.5f, 0.5f), transform.GetChild(0).position.y + Random.Range(-0.5f, 0.5f), 0), Quaternion.identity, transform);
                    }
                    bulletPrefab.GetComponent<Bullet>().player = gameObject;
                    bulletTime = 0;
                }
            }

        }
        else
        {
            timer2 += Time.deltaTime;
            if (timer2 >= cooldownCadencia)
            {
                if (cadencia >= cadenciaRef)
                    cadencia = cadenciaRef;
                else
                    cadencia += sumaCadencia;

                timer2 = 0;
            }
            if (totalBulletTime >= 0)
            {
                totalBulletTime -= Time.deltaTime * 1.1f;
            }
            else
            {
                totalBulletTime = 0;
            }
        }

        if (totalBulletTime > timeShoting)
        {
            canShot = false;
        }

        if (!canShot)
        {
            totalBulletTime -= Time.deltaTime * 1.1f;
            if (totalBulletTime <= 0)
            {
                print("holi");
                canShot = true;
                totalBulletTime = 0;
                cadencia = cadenciaRef;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            Debug.Log("Hited");
        }
    }
}
