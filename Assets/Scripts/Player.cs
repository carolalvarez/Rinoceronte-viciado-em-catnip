using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    Vector2 force;

    [SerializeField]
    float holdMouseTime;

    [SerializeField]
    GameObject bulletPrefab;

    GameManager gameManager;
    GameObject bullet_;

    Vector2 startPos;
    Rigidbody2D rb;

    [SerializeField]
    float cadencia;

    float cadenciaRef;
    float holdTime = 0;
    float timer = 0;
    float timer2 = 0;

    [SerializeField]
    float cooldownCadencia;

    [SerializeField]
    float topeCadencia;

    [SerializeField]
    float sumaCadencia = 0;

    [SerializeField]
    float timeShoting = 0;


    float bulletTime = 0;
    [SerializeField]
    float totalBulletTime = 0;

    [SerializeField]
    Slider CadenciaBarr;
    [SerializeField]
    bool canShot;

    bool ispressing, onTrigger;
    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        cadenciaRef = cadencia;
        gameManager = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;
        CadenciaBarr.maxValue = timeShoting;
        canShot = true;
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //print(timer);
        //Funcionamiento del Impulso
        CadenciaBarr.value = totalBulletTime;
        //if (Input.GetMouseButton(1))
        //{
        //    rb.velocity += new Vector2(5 * Time.deltaTime, 0);
        //    //else rb.velocity = Vector2.zero;
        //}
        //else
        //{
        //    //if (!onTrigger)
        //    rb.velocity -= new Vector2(4 * Time.deltaTime, 0);
        //    //else rb.velocity = Vector2.zero;
        //}
        ////if (Input.GetMouseButton(1))
        //{
        //    holdTime += Time.deltaTime;
        //    print(holdTime);
        //}
        //if (Input.GetMouseButtonUp(1) && holdTime >= holdMouseTime)
        //{
        //    rb.AddForce(force, ForceMode2D.Impulse);
        //}
        //else if (Input.GetMouseButtonUp(1))
        //{
        //    holdTime = 0;
        //}

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
            print("control");
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
}
