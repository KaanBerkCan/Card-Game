using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    //public int boardX, boardY; //e�er oyun i�i g�ncelleyeceksek kanvasa uymas� i�in scale de de�i�mesi laz�m zor geldi

    public GameObject[,] boardPlanes = new GameObject[10,10];
    void Start()
    {
        
    }
    public void goBack()
    {
        
        foreach (GameObject loopObject in boardPlanes)
        {
            if(loopObject!=null)
            {
               
                PlaneChange sc = loopObject.GetComponent<PlaneChange>();
                //sc.dontChangeColor = false;
                //sc.isAboutToPlay = false;
                sc.returnOriginal();
            }


        }
    }


    //public void changeBoard()
    //{

    //}
}
