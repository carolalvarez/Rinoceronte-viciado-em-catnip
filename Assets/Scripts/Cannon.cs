using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    void Update()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        transform.up = direction;
        LimitRot();
    }

    private void LimitRot()
    {
        if (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 180)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 270);

        else if (transform.eulerAngles.z < 180 && transform.eulerAngles.z > 90)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
    }
}
