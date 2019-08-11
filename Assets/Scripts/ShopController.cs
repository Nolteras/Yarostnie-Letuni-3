using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    [Header("Drugoe")]
    public GameObject shopPanel;
    public GameObject World;
    public GameObject camera;
    public GameObject ResPanel;
    public bool BazaBuild = false;

    [Header("Postroiki")]
    public GameObject baza;
    public GameObject wood;
    public GameObject farm;
    public GameObject house;
    public GameObject upgrade;

    [Header("Oshibki")]
    public GameObject BazaError;
    public GameObject ResError;
    public GameObject BazaNeed;

    [Header("Stoimost'")]
    public GameObject woodSt; //Кнопка, в которой написаны цены для дерева
    public GameObject farmSt; //Кнопка, в которой написаны цены для фермы
    public GameObject houseSt; //Кнопка, в которой написаны цены для дома
    public GameObject updateSt; //Кнопка, в которой написаны цены для улучшения





    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Cansel() //Вызвав этот метод, закрытие панели
    {
        BazaNeed.SetActive(false);
        BazaError.SetActive(false); // Отключает сообщения о том, что база есть
        ResError.SetActive(false);  //Отключает то, что ресурсы есть
        shopPanel.SetActive(false); // Отключает сам магазин

        for (int i = 0; i < World.transform.childCount; i++) // Перебирает все клетки
        {
            if (World.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true) //Ищет активную
            {
                World.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell = false; //Выключает её и останавливает цикл
                break;
            }
        }

    }

    public void BuildBaza()
    {
        if (BazaBuild)
        {
            BazaError.SetActive(true);
            return;
        }


        for (int i = 0; i < World.transform.childCount; i++) // Перебирает все клетки для того, чтобы узнать, есть ли на клетке постройка
        {
            if (World.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true && World.transform.GetChild(i).GetComponent<BuildManager>().building == false) //Ищет помеченную клетку
            {
                World.transform.GetChild(i).GetComponent<BuildManager>().CreateBuilding(baza); //Ставит на клетку БАЗУ
                BazaBuild = true;
                Cansel();
                break;
            }
        }
    }


    public void BuildUpdate()
    {
        if (BazaBuild == false)
        {
            BazaNeed.SetActive(true);
            return;
        }

        if (ResPanel.GetComponent<ResourseController>().money < updateSt.GetComponent<UpdatePrise>().CenaMoney || ResPanel.GetComponent<ResourseController>().wood < updateSt.GetComponent<UpdatePrise>().CenaWood) // Проверяет, хватает ли денег и дерева, заданные в кнопке
        {
            ResError.SetActive(true);
            return;
        }


        for (int i = 0; i < World.transform.childCount; i++) // Перебирает все клетки для того, чтобы узнать, есть ли на клетке постройка
        {
            if (World.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true && World.transform.GetChild(i).GetComponent<BuildManager>().building == true) //Ищет помеченную клетку
            {
                if(World.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true && World.transform.GetChild(i).GetComponent<BuildManager>().upgrade == false)
                {   
                 World.transform.GetChild(i).GetComponent<BuildManager>().setUpdate(upgrade); //Ставит на клетку АПДЕЙТ
                 ResPanel.GetComponent<ResourseController>().money -= updateSt.GetComponent<UpdatePrise>().CenaMoney; //Отнимает цену
                 ResPanel.GetComponent<ResourseController>().wood -= updateSt.GetComponent<UpdatePrise>().CenaWood; //Отнимает цену
                 break;
                }
            }
        }
        Cansel();


    }



    public void BuildWood()
    {

        if(BazaBuild == false)
        {
            BazaNeed.SetActive(true);
            return;
        }

        if (ResPanel.GetComponent<ResourseController>().money < woodSt.GetComponent<WoodPrise>().CenaMoney || ResPanel.GetComponent<ResourseController>().wood < woodSt.GetComponent<WoodPrise>().CenaWood) // Проверяет, хватает ли денег и дерева, заданные в кнопке
        {
            ResError.SetActive(true);
            return;
        }
        for (int i = 0; i < World.transform.childCount; i++) // Перебирает все клетки для того, чтобы узнать, есть ли на клетке постройка
        {
            if (World.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true && World.transform.GetChild(i).GetComponent<BuildManager>().building == false) //Ищет помеченную клетку
            {
                World.transform.GetChild(i).GetComponent<BuildManager>().CreateBuilding(wood); //Ставит на клетку ДЕРЕВО
                ResPanel.GetComponent<ResourseController>().money -= woodSt.GetComponent<WoodPrise>().CenaMoney; //Отнимает цену
                ResPanel.GetComponent<ResourseController>().wood -= woodSt.GetComponent<WoodPrise>().CenaWood; //Отнимает цену
                Cansel();
                break;
            }
        }
    }

    public void BuildFarm()
    {

        if (BazaBuild == false)
        {
            BazaNeed.SetActive(true);
            return;
        }


        if (ResPanel.GetComponent<ResourseController>().money < farmSt.GetComponent<FarmPrise>().CenaMoney || ResPanel.GetComponent<ResourseController>().wood < farmSt.GetComponent<FarmPrise>().CenaWood) // Проверяет, хватает ли денег и дерева, заданные в кнопке
        {
            ResError.SetActive(true);
            return;
        }
        for (int i = 0; i < World.transform.childCount; i++) // Перебирает все клетки для того, чтобы узнать, есть ли на клетке постройка
        {
            if (World.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true && World.transform.GetChild(i).GetComponent<BuildManager>().building == false) //Ищет помеченную клетку
            {
                World.transform.GetChild(i).GetComponent<BuildManager>().CreateBuilding(farm); //Ставит на клетку ФЕРМУ
                ResPanel.GetComponent<ResourseController>().money -= farmSt.GetComponent<FarmPrise>().CenaMoney; //Отнимает цену
                ResPanel.GetComponent<ResourseController>().wood -= farmSt.GetComponent<FarmPrise>().CenaWood; //Отнимает цену
                Cansel();
                break;
            }
        }
    }

    public void BuildHouse()
    {

        if (BazaBuild == false)
        {
            BazaNeed.SetActive(true);
            return;
        }


        if (ResPanel.GetComponent<ResourseController>().money < houseSt.GetComponent<HousePrise>().CenaMoney || ResPanel.GetComponent<ResourseController>().wood < houseSt.GetComponent<HousePrise>().CenaWood) // Проверяет, хватает ли денег и дерева, заданные в кнопке
        {
            ResError.SetActive(true);
            return;
        }
        for (int i = 0; i < World.transform.childCount; i++) // Перебирает все клетки для того, чтобы узнать, есть ли на клетке постройка
        {
            if (World.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true && World.transform.GetChild(i).GetComponent<BuildManager>().building == false) //Ищет помеченную клетку
            {
                World.transform.GetChild(i).GetComponent<BuildManager>().CreateBuilding(house); //Ставит на клетку ДОМ
                ResPanel.GetComponent<ResourseController>().money -= houseSt.GetComponent<HousePrise>().CenaMoney; //Отнимает цену
                ResPanel.GetComponent<ResourseController>().wood -= houseSt.GetComponent<HousePrise>().CenaWood; //Отнимает цену
                Cansel();
                break;
            }
        }
    }


}
