using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baza : MonoBehaviour
{

    GameObject resourses;
    private int people;
    public int peopleAdd;
    float peopleTime = 0;
    private int food;
    public int foodUse;
    float foodTime;
    public int peopleDied;
    float peopleDeadTime;
    public int tax;
    public int taxAdd;
    float taxTime;

    void Start()
    {
        resourses = GameObject.FindGameObjectWithTag("ResControl"); //Ссылается на объект с тэгом     
        resourses.GetComponent<ResourseController>().people += 10;
        people = resourses.GetComponent<ResourseController>().people;
        food = resourses.GetComponent<ResourseController>().food;
    }

    


    void Update()
    {


        residentAdd();
        Product();

    }

    void residentAdd()
    {

        while (peopleTime < peopleAdd) //Проверяет, прошло ли время для добавления человека
        {
            peopleTime = 1 * Time.deltaTime;
            people += 1;                                             // Добавляет
            resourses.GetComponent<ResourseController>().people += 1;
        }

        peopleTime = 0; //Обнуляет счетчик

    }

    void Product()
    {
        int allFoodSojrano;
        foodTime += 1 * Time.deltaTime;
        if(foodTime > foodUse)
        {
            allFoodSojrano = people * foodUse;
            if(allFoodSojrano <= resourses.GetComponent<ResourseController>().food)
            {
                resourses.GetComponent<ResourseController>().food -= allFoodSojrano;
            }
            else if(allFoodSojrano > resourses.GetComponent<ResourseController>().food)
            {
                while(allFoodSojrano > resourses.GetComponent<ResourseController>().food)
                {
                    people -= 1;
                    resourses.GetComponent<ResourseController>().people -= 1;
                    allFoodSojrano -= 1;
                }
            }
            allFoodSojrano = 0;
            foodTime = 0;
            if (people < 0)
            {
                people = 0;
                resourses.GetComponent<ResourseController>().people = 0;

            }
        }
    }

}
