using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baza : MonoBehaviour
{


    GameObject resourses;

    private void Start()
    {
        resourses = GameObject.FindGameObjectWithTag("ResControl");
        resourses.GetComponent<ResourseController>().people += 1;
    }



}
