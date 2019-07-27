using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourseController : MonoBehaviour
{

    public Text ResText;
    [Header("Resources")]
    public int people;
    public int money;
    public int wood;


    void Update()
    {
        ResText.text = "Поселенцев: " + people + 
    }
}
