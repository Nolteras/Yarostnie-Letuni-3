using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CargoFriend : MonoBehaviour
{


    GameObject Planet;
    Rigidbody2D rigidbody;
    int speed = 10;
    float doStuffTime;
    float doStuffTimeEnd = 5;

    void Start()
    {
        Planet = GameObject.FindGameObjectWithTag("Planet");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        doStuffTime += 1 * Time.deltaTime;
        if(doStuffTime < doStuffTimeEnd)
        {
            return;
        }
        MoveToClosePlanet();
        doStuffTime = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Stikovka");
        }

        if(other.tag == "Planet")
        {

            gameObject.SetActive(false);
        }

    }

    void MoveToClosePlanet()
    {

        Vector2 vectorToPlanet = Planet.transform.position - transform.position;
        rigidbody.velocity = new Vector2(vectorToPlanet.x + speed, vectorToPlanet.y + speed);
    }
}
