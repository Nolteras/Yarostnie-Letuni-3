using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetScript : MonoBehaviour
{


    GameObject InfoPlanet;

    void Start()
    {
        InfoPlanet = GameObject.Find("PlanetState"); //Находит объект, в котором хранится информация о планете
        InfoPlanet.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            InfoPlanet.SetActive(true);
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            InfoPlanet.SetActive(false);
        }
    }


}
