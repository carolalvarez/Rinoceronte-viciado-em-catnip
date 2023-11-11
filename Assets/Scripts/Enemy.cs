using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum STATES { ENTRING, MOVING, DECELERATING, SPEEDUP }
    public STATES state;
    Rigidbody2D rb;
    [SerializeField] private float Speed, DecelerateFactor, SpeedUpFactor, ElocoidFactor;
    float timer = 2f, speedRef, elicoidTimer, elicoidTimerRef;
    bool onTrigger;
    int random = 7;
    [SerializeField]
    int health = 0;
    AudioSource EnemyAudio;

    float timer_ = 0;
    void Start()
    {
        EnemyAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        speedRef = Speed;
        elicoidTimer = Random.Range(0.5f, 1);
        elicoidTimerRef = elicoidTimer;
        state = STATES.ENTRING;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case STATES.ENTRING:
                {
                    Entring();
                }
                break;
            case STATES.DECELERATING:
                {
                    Decelerate();
                }
                break;
            case STATES.SPEEDUP:
                {
                    SpeedUp();
                }
                break;
            case STATES.MOVING:
                {
                    elicoidTimer -= Time.deltaTime;
                    if (elicoidTimer <= 0)
                    {
                        ElocoidFactor *= -1;
                        elicoidTimer = elicoidTimerRef;
                    }
                    transform.position = new Vector2(transform.position.x, transform.position.y + ElocoidFactor * Time.deltaTime);

                    rb.velocity = transform.right * Speed;
                    Randomizer();
                }
                break;
        }
        if(health<=0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Left" && state != STATES.ENTRING)
        {
            onTrigger=true;
            state = STATES.DECELERATING;
        }
        else if (collision.tag == "Right" && state != STATES.ENTRING)
        {
            onTrigger = true;
            state = STATES.DECELERATING;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Left"|| collision.tag == "Right")
            onTrigger = false;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyAudio.Play();
            health--;
            Destroy(collision.gameObject);
        }
    }

    private void Entring()
    {
        transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
        timer_ += Time.deltaTime;
        if (timer_ > 2)
            state = STATES.MOVING;
    }
    private void Randomizer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            random = Random.Range(0, 4);
            if (random == 0&&!onTrigger)
                state = STATES.DECELERATING;
            timer = 2;
        }
    }
    private void Decelerate()
    {
        if (Speed > 0)
        {
            Speed -= Time.deltaTime * DecelerateFactor;
            if (Speed <= 0)
            {
                Speed = 0;
                transform.right *= -1;
                transform.GetComponent<SpriteRenderer>().flipX = !transform.GetComponent<SpriteRenderer>().flipX;
                state = STATES.SPEEDUP;
            }
        }
    }
    private void SpeedUp()
    {
        if (Speed < speedRef)
        {
            Speed += SpeedUpFactor*Time.deltaTime;
            if(Speed>=speedRef)
            {
                Speed=speedRef;
                state = STATES.MOVING;
            }
        }
    }
}
