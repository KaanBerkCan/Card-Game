using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inactive : MonoBehaviour
{
    public GameObject CloseOrOpen;

    //2 tip a�ma kapama yazd�m, close �zerine atand��� objeyi kapat�r
    // di�eri ise uzaktan istedi�i objeyi inaktif veya aktif eder
    public void close()
    {
        gameObject.SetActive(false);
    }

    public void closeOrOpen()
    {
        if(CloseOrOpen.activeSelf)
            CloseOrOpen.SetActive(false);
        else
            CloseOrOpen.SetActive(true);
    }
   
}
