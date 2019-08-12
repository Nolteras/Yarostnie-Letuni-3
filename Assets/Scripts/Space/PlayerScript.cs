using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigid;
    public int speed;
    public bool CanMove = true;
    float x;
    float y;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CanMove)
        {
            movement();
        }
    }


    void movement()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        rigid.velocity = new Vector2(x * speed, y * speed);
    }

}
