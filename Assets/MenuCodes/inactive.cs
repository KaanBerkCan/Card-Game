using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inactive : MonoBehaviour
{
    public GameObject CloseOrOpen;

    //2 tip açma kapama yazdým, close üzerine atandýðý objeyi kapatýr
    // diðeri ise uzaktan istediði objeyi inaktif veya aktif eder
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
