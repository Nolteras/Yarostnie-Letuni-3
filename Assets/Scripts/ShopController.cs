using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    [Header("Drugoe")]
    public GameObject shopPanel;
    public GameObject AllCells;
    public AudioClip clip;
    public GameObject camera;
    public bool BazaBuild = false;

    [Header("Postroiki")]
    public GameObject baza;
    public GameObject wood;
    public GameObject farm;





    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Cansel() //Вызвав этот метод, закрытие панели
    {
        shopPanel.SetActive(false);

        for(int i = 0; i < AllCells.transform.childCount; i++) // Перебирает все клетки
        {
            if (AllCells.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true) //Ищет активную
            {
                AllCells.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell = false; //Выключает её и останавливает цикл
                break;
            }
        }

    }

    public void BuildBaza()
    {
        if (BazaBuild)
        {
            return;
        }
        for (int i = 0; i < AllCells.transform.childCount; i++) // Перебирает все клетки для того, чтобы узнать, есть ли на клетке постройка
        {
            if (AllCells.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true && AllCells.transform.GetChild(i).GetComponent<BuildManager>().building == false) //Ищет помеченную клетку
            {
                AllCells.transform.GetChild(i).GetComponent<BuildManager>().CreateBuilding(baza); //Ставит на клетку БАЗУ
                BazaBuild = true;
                AudioSource.PlayClipAtPoint(clip, camera.transform.position);
                break;
            }
        }
    }

    public void BuildWood()
    {
        for (int i = 0; i < AllCells.transform.childCount; i++) // Перебирает все клетки для того, чтобы узнать, есть ли на клетке постройка
        {
            if (AllCells.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true && AllCells.transform.GetChild(i).GetComponent<BuildManager>().building == false) //Ищет помеченную клетку
            {
                AllCells.transform.GetChild(i).GetComponent<BuildManager>().CreateBuilding(wood); //Ставит на клетку ДЕРЕВО
                break;
            }
        }
    }

    public void BuildFarm()
    {
        for (int i = 0; i < AllCells.transform.childCount; i++) // Перебирает все клетки для того, чтобы узнать, есть ли на клетке постройка
        {
            if (AllCells.transform.GetChild(i).GetComponent<BuildManager>().ActiveCell == true && AllCells.transform.GetChild(i).GetComponent<BuildManager>().building == false) //Ищет помеченную клетку
            {
                AllCells.transform.GetChild(i).GetComponent<BuildManager>().CreateBuilding(farm); //Ставит на клетку ФЕРМУ
                break;
            }
        }
    }


}
