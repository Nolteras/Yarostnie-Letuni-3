using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public int workmans;
    public int maxWorkmans;
    public int HireTime;
    float hireWorkman;
    public int WorkTime;
    int WoodOutput;
    public int WoodEff;
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
        hireWorkman += 1 * Time.deltaTime;
        if (hireWorkman >= HireTime)
        {
            if (resourses.GetComponent<ResourseController>().workers < resourses.GetComponent<ResourseController>().people)
            {
                if (workmans < maxWorkmans)
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
        if (resourses.GetComponent<ResourseController>().workers > resourses.GetComponent<ResourseController>().people)
        {
            workmans--;
            resourses.GetComponent<ResourseController>().workers--;
        }
    }


    void Rabota()
    {
        if (workmans != 0)
        {
            WorkTimer += 1 * Time.deltaTime;
            if (WorkTimer >= WorkTime)
            {
                for (int i = 0; i <= maxWorkmans; i++)
                {
                    WoodOutput += WoodEff;
                }
                resourses.GetComponent<ResourseController>().wood += WoodOutput;
                WorkTimer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Upgrade")
        {
            maxWorkmans += 3;
            WoodEff += 5;
        }
    }

}
