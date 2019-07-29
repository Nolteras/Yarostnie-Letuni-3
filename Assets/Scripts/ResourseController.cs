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
    public int food;
    public int workers = 0;


    void Update()
    {

        if(food < 0)
        {
            food = 0;
        }

        if(people < 0)
        {
            people = 0;
        }

        if (workers < 0)
        {
            workers = 0;
        }


        ResText.text = "Поселенцев: " + people + "   Деньги: " + money + "   Дерево: " + wood +
            "\r\nЕды: " + food + "   Работяги: " + workers;

    }
}
