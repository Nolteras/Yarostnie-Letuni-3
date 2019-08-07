using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{


    public int resident; //В доме люей
    public int maxResident; //Максимум людей в доме
    public int residentAdd; //Через сколько будет появляться житель (секунды)
    float residentTime;
    public int product; //Сколько ест один человек
    public int productUse; //Как часто он ест(секунды)
    float productTime;
    public int residentDead; //Как часто будет умирать один житель(секунды)
    float residentDeadTime;
    public int tax; //Нологи
    public int taxAdd; //Как часто(секунды)
    float taxTime;

    GameObject resourses;

    void Start()
    {
        resourses = GameObject.FindGameObjectWithTag("ResControl");
    }

    
    void Update()
    {

        if(resident < 0) //Не даёт уйти в минус людям
        {
            resident = 0;
        }

        NOLOGI();
        ResidentAdd();
        Product();
        Died();
    }

    void ResidentAdd()
    {
        residentTime += 1 * Time.deltaTime; //Добавляет в счечик одну секунду
        if(residentTime >= residentAdd) //Если счетчик досчитывает до времени, нужного для появления нового жителя
        {
            if(resident < maxResident) //Если людей меньше, чем может быть в доме, добавляет жителя
            {
                if(resourses.GetComponent<ResourseController>().food != 0) //Если еды нет, никто не появляется
                {
                    resident++;
                    resourses.GetComponent<ResourseController>().people++;
                }
            }

            residentTime = 0; //Обнуляет счетчик
        }
    }


    void Product()
    {
        int EdiSojrano; //Сколько всего ест население дома

        productTime += 1 * Time.deltaTime; //Счетчик до еды

        if(productTime >= productUse)
        {
            EdiSojrano = resident * product; //Один житель дома ест столько, сколько указывается выше

            if(EdiSojrano <= resourses.GetComponent<ResourseController>().food) //Если потребление меньше или равно текущему запасу, люди едят
            {
                resourses.GetComponent<ResourseController>().food -= EdiSojrano;
            }
            else if(EdiSojrano > resourses.GetComponent<ResourseController>().food) //Если потребление больше текущего запаса
            {
                while(EdiSojrano > resourses.GetComponent<ResourseController>().food) //Пока потребление больше текущего запаса
                {
                    resident--; //То житель умирает от голода
                    resourses.GetComponent<ResourseController>().people--;
                    EdiSojrano--; //Потребление падает
                }
            }
            EdiSojrano = 0;
            productTime = 0;

        }



    }


    void NOLOGI()
    {
        int NologiSoVseh; //Всего нологов

        taxTime += 1 * Time.deltaTime;

        if (taxTime >= taxAdd)
        {
            NologiSoVseh = resident * tax; //Один житель платит сумму, которая записана в налогах
            resourses.GetComponent<ResourseController>().money += NologiSoVseh;
            NologiSoVseh = 0;
            taxTime = 0;
        }

    }



    void Died()
    {
        residentDeadTime = 1 * Time.deltaTime; //Один житель умирает в опредёленный промежуток, ничего интересного

        if(residentDeadTime >= residentDead)
        {
            resident--;
            resourses.GetComponent<ResourseController>().people--;
            residentDeadTime = 0;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Upgrade")
        {
            maxResident += 3;
            tax += 10;
        }
    }

}
