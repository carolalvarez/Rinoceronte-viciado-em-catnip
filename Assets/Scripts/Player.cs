using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Vector2 force;

    [SerializeField]
    float holdMouseTime;

    [SerializeField]
    GameObject bulletPrefab;

    GameController gameController;
    GameObject bullet_;

    Vector2 startPos;
    Rigidbody2D rb;

    [SerializeField]
    float cadencia;

    float cadenciaRef;
    float holdTime = 0;
    float timer = 0;

    [SerializeField]
    float cooldownCadencia;

    [SerializeField]
    float topeCadencia;

    [SerializeField]
    float sumaCadencia = 0;

    float bulletTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        cadenciaRef = cadencia;
        gameController = FindAnyObjectByType<GameController>();
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        //print(timer);
        //Funcionamiento del Impulso
        if (Input.GetMouseButton(1))
        {
            holdTime += Time.deltaTime;
            print(holdTime);
        }
        if (Input.GetMouseButtonUp(1) && holdTime >= holdMouseTime)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            holdTime = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            cadencia = cadenciaRef;
        }
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
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
                if (gameController.pull.Count != 0)
                {
                    bullet_ = gameController.pull[0];
                    gameController.ActiveBullet();
                    bullet_.transform.position = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), 0);
                    bullet_.GetComponent<Bullet>().Movement();
                }
                else
                {
                    bullet_ = Instantiate(bulletPrefab, new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), 0), Quaternion.identity, transform);
                }
                bulletPrefab.GetComponent<Bullet>().player = gameObject;
                bulletTime = 0;
            }


        }
    }


}
