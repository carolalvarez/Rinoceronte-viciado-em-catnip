using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoSniff : MonoBehaviour
{
    public Sprite[] rinoSprites = new Sprite[1];
    SpriteRenderer rinoRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rinoRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
        {
            rinoRenderer.sprite = rinoSprites[0];
            print("sprite1");
        }
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            rinoRenderer.sprite = rinoSprites[1];
            print("sprite2");
        }
    }
}
