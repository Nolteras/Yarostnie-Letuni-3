using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Farm : MonoBehaviour
{

    public int workmans;
    public int maxWorkmans;
    public int HireTime;
    float hireWorkman;
    public int WorkTime;
    int FoodOutput;
    public int FoodEff;
    float WorkTimer;


    GameObject resourses;


    void Start()
    {
        resourses = GameObject.FindGameObjectWithTag("ResControl");
    }

    
    void Update()
    {
        ChechForDead();
        Hire();
        Rabota();
    }


    void Hire()
    {      
        hireWorkman += 1 * Time.deltaTime; //Запускаяет счетчик
        if(hireWorkman >= HireTime)
        {
            if(resourses.GetComponent<ResourseController>().workers < resourses.GetComponent<ResourseController>().people) //Если в поселении рабочих меньше населения
            {
                if (workmans < maxWorkmans) //Если в здании есть место для рабочих
                {
                    workmans++;
                    resourses.GetComponent<ResourseController>().workers++;
                }
              
            }
            hireWorkman = 0;

        }

    }


    void ChechForDead()
    {
        if (resourses.GetComponent<ResourseController>().workers > resourses.GetComponent<ResourseController>().people) //Если рабочих больше, чем населения, то убирает рабочего
        {
            workmans--;
            resourses.GetComponent<ResourseController>().workers--;
        }
    }


    void Rabota()
    {
        if(workmans != 0)
        {
            WorkTimer += 1 * Time.deltaTime;
            if (WorkTimer >= WorkTime)
            {
                for (int i = 0; i <= maxWorkmans; i++) //Добавляет "работу" за каждого работягу
                {
                    FoodOutput += FoodEff;
                }
                resourses.GetComponent<ResourseController>().food += FoodOutput;
                WorkTimer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Upgrade")
        {
            maxWorkmans += 3;
            FoodEff += 5;
        }
    }



}
