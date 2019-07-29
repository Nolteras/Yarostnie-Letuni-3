using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    [Header("Drugoe")]
    public GameObject shopPanel;
    public GameObject World;
    public AudioClip clip;
    public GameObject camera;
    public GameObject ResPanel;
    public bool BazaBuild = false;

    [Header("Postroiki")]
    public GameObject baza;
    public GameObject wood;
    public GameObject farm;
    public GameObject house;

    [Header("Oshibki")]
    public GameObject BazaError;
    public GameObject ResError;

    [Header("Stoimost'")]
    public GameObject woodSt; //Кнопка, в которой написаны цены для дерева
    public GameObject farmSt; //Кнопка, в которой написаны цены для фермы
    public GameObject houseSt; //Кнопка, в которой написаны цены для дома





    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Cansel() //Вызвав этот метод, закрытие панели
    {
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
                AudioSource.PlayClipAtPoint(clip, camera.transform.position);
                Cansel();
                break;
            }
        }
    }

    public void BuildWood()
    {
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
        if (ResPanel.GetComponent<ResourseController>().money < farmSt.GetComponent<FarmPrise>().CenaMoney || ResPanel.GetComponent<ResourseController>().money < farmSt.GetComponent<FarmPrise>().CenaWood) // Проверяет, хватает ли денег и дерева, заданные в кнопке
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
