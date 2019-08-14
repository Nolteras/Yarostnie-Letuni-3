using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetScript : MonoBehaviour
{
    [Header("Panels")]
    public  GameObject InfoPlanet;
    public GameObject ActionPlanetPort;
    public GameObject ActionPlanetBar;
    public GameObject ActionPlanetSquare;
    public GameObject ActionPlanetAdmin;
    GameObject Player;
    AudioSource audioPort;
    AudioSource audioBar;
    AudioSource audioSquare;
    bool frombar;

    void Start()
    {
        Player = GameObject.Find("Player");
        audioBar = ActionPlanetBar.GetComponent<AudioSource>();
        audioPort = Player.transform.GetChild(0).GetComponent<AudioSource>();
        audioSquare = ActionPlanetSquare.GetComponent<AudioSource>();
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
        frombar = true;
        audioPort.Stop();
        audioBar.Play();
        ActionPlanetBar.SetActive(true);
        ActionPlanetSquare.SetActive(false);
    }

    public void GoSquere()
    {
        if (frombar)
        {
            audioBar.Stop();
            audioPort.Play();
            frombar = false;
            ActionPlanetBar.SetActive(false);
        }
        ActionPlanetPort.SetActive(false);
        ActionPlanetSquare.SetActive(true);
    }

    public void GoPort()
    {
        if (ActionPlanetAdmin.active)
        {
            ActionPlanetAdmin.SetActive(false);
        }
        ActionPlanetPort.SetActive(true);
        ActionPlanetSquare.SetActive(false);
    }

    public void GoAdministr()
    {
        ActionPlanetPort.SetActive(false);
        ActionPlanetAdmin.SetActive(true);
    }

}
