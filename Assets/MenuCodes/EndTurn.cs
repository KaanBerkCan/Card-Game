using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    GameManager GameManager;

    public Camera[] kameralar;
    public GameObject[] canvaslar;

    public GameObject[] player1PlayablePlanes;
    public GameObject[] player2PlayablePlanes;

    //public board boardscript;
    void Start()
    {
        //boardscript = GameObject.FindGameObjectWithTag("board").GetComponent<board>();
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        kameralar[1].enabled = false;
        canvaslar[1].SetActive(false);
        kameralar[1].gameObject.SetActive(false);
        ChangePlayablePlanes(1);
    }

    //public void FindPlayableArray()
    //{
    //    int i = 0;
    //    int i2 = 0;
     
    //    foreach (GameObject loopObject in boardscript.boardPlanes)
    //    {
    //        if (loopObject.GetComponent<PlaneChange>().matrisY == 9)
    //        {
    //            player1PlayablePlanes[i] = loopObject;
    //            i += 1;
    //        }
    //        else if (loopObject.GetComponent<PlaneChange>().matrisY == 1)
    //        {
    //            player2PlayablePlanes[i2] = loopObject;
    //            i2 += 1;
    //        }
    //    }
    //}
    public void EndTurnButton()
    {
        GameManager.CurrentMana = 10;
        GameManager.UseMana(0);//güncellensin diye
        if (GameManager.PlayerNumTurn == 1)
        {
            
           
            GameManager.PlayerNumTurn = 2;
            kameralar[0].gameObject.SetActive(false);
            kameralar[1].gameObject.SetActive(true);
            kameralar[0].enabled = false;
            kameralar[1].enabled = true;
            canvaslar[0].SetActive(false);
            canvaslar[1].SetActive(true);
            ChangePlayablePlanes(2);
        }
        else if (GameManager.PlayerNumTurn == 2)
        {
            
            
            GameManager.PlayerNumTurn = 1;
            kameralar[1].gameObject.SetActive(false);
            kameralar[0].gameObject.SetActive(true);
            kameralar[1].enabled = false;
            kameralar[0].enabled = true;
            canvaslar[1].SetActive(false);
            canvaslar[0].SetActive(true);
            ChangePlayablePlanes(1);
        }

    
        GetComponent<DeckHolder>().CardPositions();
    }

    private void ChangePlayablePlanes(int player)
    {
        if (player==1)
        {
            foreach (GameObject loopObject in player1PlayablePlanes)
            {
                if (loopObject != null)
                {
                    PlaneChange sc = loopObject.GetComponent<PlaneChange>();
                    sc.canPlayMinion = true;
                }
            }
            foreach (GameObject loopObject in player2PlayablePlanes)
            {
                if (loopObject != null)
                {
                    PlaneChange sc = loopObject.GetComponent<PlaneChange>();
                    sc.canPlayMinion = false;
                }
            }
        }

        if (player == 2)
        {
            foreach (GameObject loopObject in player2PlayablePlanes)
            {
                if (loopObject != null)
                {
                    PlaneChange sc = loopObject.GetComponent<PlaneChange>();
                    sc.canPlayMinion = true;
                }
            }
            foreach (GameObject loopObject in player1PlayablePlanes)
            {
                if (loopObject != null)
                {
                    PlaneChange sc = loopObject.GetComponent<PlaneChange>();
                    sc.canPlayMinion = false;
                }
            }
        }
    }

}
