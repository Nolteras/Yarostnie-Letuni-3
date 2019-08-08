using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    int screenWidth;
    int screenHeight;

    public float speed;

    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    void Update()
    {
        Vector3 CameraPos = transform.position;
        if(Input.mousePosition.x < 20)
        {
            Debug.Log("mousePosition.x < 20");
            CameraPos.x -= speed * Time.deltaTime;
        }
        else if(Input.mousePosition.y < 20)
        {
            Debug.Log("mousePosition.y < 20");
            CameraPos.y -= speed * Time.deltaTime;
        }
        else if(Input.mousePosition.x > screenWidth - 20)
        {
            Debug.Log("mousePosition.x > screenWidth - 20");
            CameraPos.x += speed * Time.deltaTime;
        }
        else if (Input.mousePosition.y > screenHeight - 20)
        {
            Debug.Log("mousePosition.y > screenWidth - 20");
            CameraPos.y += speed * Time.deltaTime;
        }

        transform.position = new Vector3(Mathf.Clamp(CameraPos.x, 160, 840), Mathf.Clamp(CameraPos.y, 150, 500), CameraPos.z);

    }
}
