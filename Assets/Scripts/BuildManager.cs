using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{


    public bool building;

    public bool upgrade;

    public GameObject shopPanel;

    public bool water;

    public bool ActiveCell; // true - используется магазином

    void Start()
    {
        
    }

    
    void Update()
    {
        if (shopPanel.active) // Если панель активна, ничего не работает
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && (transform.GetChild(0).GetComponent<Image>().color == Color.green || transform.GetChild(0).GetComponent<Image>().color == Color.yellow)) //Если нажата лкм и ячейка зелёная(или желтая), то магазин открывается
        {
            if (!water) //Если воды нет, то магазин открывается
            {
                shopPanel.SetActive(true);
                ActiveCell = true; //Помечает клетку
            }
            
        }
    }

    private void OnMouseEnter()
    {
        if (shopPanel.active)
        {
            return;
        }
        if (water)
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.blue; //Если это вода, то меняет цвет на синий.
            return;
        }
        if (building && !upgrade)
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.yellow; //Если есть постройка, но без апгрейдом, то меняет цвет на желтый.
            return;
        }
        if (building && upgrade)
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.red; //Если есть постройка c апгрейдом, то меняет цвет на красный.
            return;
        }
        if( !water || !building)
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.green; // При вхождении меняет цвет ячейки на зелёный.
            return;
        }
    }

    private void OnMouseExit()
    {
        transform.GetChild(0).GetComponent<Image>().color = Color.white; // При выходе меняет цвет ячейкий на белый.
    }

    public void CreateBuilding(GameObject build) //Скрипт для создания построек
    {
        Instantiate(build).transform.position = transform.GetChild(1).position; //Положение постройки списывает положение точки
        building = true; //Здание построено
        ActiveCell = false;//Клетка не активна
    }


    public void setUpdate(GameObject upgrade2)
    {
        Instantiate(upgrade2).transform.position = transform.GetChild(2).position; //Положение постройки списывает положение точки
        upgrade = true;
        ActiveCell = false;
    }

}
