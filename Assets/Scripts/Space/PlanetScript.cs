using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetScript : MonoBehaviour
{

    GameObject InfoPlanet;
    GameObject Player;
    GameObject ActionPlanetPort;
    GameObject ActionPlanetBar;
    AudioSource audioPort;
    AudioSource audioBar;

    void Start()
    {
        InfoPlanet = GameObject.Find("PlanetState"); //Находит объект, в котором хранится информация о планете
        ActionPlanetPort = GameObject.Find("PlanetActionPort");
        ActionPlanetBar = GameObject.Find("PlanetActionBar");
        Player = GameObject.Find("Player");
        audioBar = ActionPlanetBar.GetComponent<AudioSource>();
        ActionPlanetBar.SetActive(false);
        InfoPlanet.SetActive(false);
        ActionPlanetPort.SetActive(false);
        audioPort = Player.transform.GetChild(0).GetComponent<AudioSource>();
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

    public void Land()
    {
        audioPort.Play();
        Player.GetComponent<PlayerScript>().CanMove = false;
        InfoPlanet.SetActive(false);
        ActionPlanetPort.SetActive(true);      
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Player.GetComponent<Transform>().position = transform.position;
    }

    public void GoBar()
    {
        audioPort.Stop();
        audioBar.Play();
        ActionPlanetBar.SetActive(true);
        InfoPlanet.SetActive(false);
    }

}
