using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodPrise : MonoBehaviour
{


    public Text priseW;
    public Text priseM;
    public int CenaWood = 0;
    public int CenaMoney = 0;

    void Start()
    {
        
    }


    void Update()
    {
        priseW.text =$"{CenaWood}"; //Заполняет один из дочерних текстов переменной, которая записана через Юнити
        priseM.text = $"{CenaMoney}"; //Заполняет один из дочерних текстов переменной, которая записана через Юнити
    }
}
