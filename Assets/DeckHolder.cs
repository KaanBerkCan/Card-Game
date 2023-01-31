using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHolder : MonoBehaviour//deck deðil de hand 
{
    public RectTransform LeftEdgePos;
    public RectTransform RightEdgePos;
    public int HandCount;//oyun içinde dinamik olarak deðiþmesi lazým //ve 2. oyuncu için  
    [SerializeField]
    private GameObject[] hand1=new GameObject[10]; //þu anlýk dýþarýdan elle atýyorum //belki deck objesi baðlanarak?
    public GameObject[] hand2 = new GameObject[10]; //þu anlýk dýþarýdan elle atýyorum
    [SerializeField]
    private GameObject[] hand;
    [SerializeField]
    private GameObject[] temphand = new GameObject[10]; 
    void Start()
    {
        CardPositions();
        //Debug.Log(LeftEdgePos.anchoredPosition.x);
        //Debug.Log(RightEdgePos.anchoredPosition.x);
    }

    public void CardPositions()
    {
        ArrangeHandArray();
        HandCount = 0;
        switch (GetComponent<GameManager>().PlayerNumTurn)
        {
            case 1:
                for (int l = 0; l < 10; l++)
                {
                    hand[l] = hand1[l];
                }
                break;

            case 2:
                for (int l = 0; l < 10; l++)
                {
                    hand[l] = hand2[l];
                }
                break;
        }

        HandCount=findHandCount(hand);

        //for (int k=HandCount;k<=10;k++)//hand arrayinden geri kalanlarý törpüleyecek
        //{
        //    hand[k] = null;
        //}



        Debug.Log("Handcount is " + HandCount);
        
        float space=(RightEdgePos.anchoredPosition.x - LeftEdgePos.anchoredPosition.x)/ HandCount;
        for (int i=0;i<= HandCount; i++)
        {
            if (HandCount <= 0)
            {
                break;
            }
            Vector3 rectpos = LeftEdgePos.anchoredPosition;
            rectpos.x = rectpos.x + space * i;
            
            if (hand[i]!=null)
            {
                hand[i].GetComponent<RectTransform>().anchoredPosition = rectpos;
            }
            //if (hand[i+1]==null)//oyun içinde handcount düzgün çalýþýrsa buna gerek kalmamalý;
            //{
            //    return;
            //}
        }
    }

 
    private int findHandCount(GameObject[] el)
    {
        int eldekikart = 0;
        foreach (GameObject loopObject in el)//daha kolay bi yolu olabilir, her seferinde eldeki kartlarý hesaplýyorum
        {
            if (loopObject != null/*||!loopObject.Equals(null)*/)
            {             
                eldekikart += 1;             
            }
        }
        return eldekikart;

    }

    private void ArrangeHandArray()
    {
        for (int l = 0; l < 10; l++)
        {
            temphand[l] = null;
        }

        int handcnt = 0;
        switch (GetComponent<GameManager>().PlayerNumTurn)
        {

            case 1:
                foreach (GameObject loopObject in hand1)
                {
                    if (loopObject != null/*||!loopObject.Equals(null)*/)
                    {
                        Debug.Log("handcnt is " + handcnt);
                        Debug.Log(loopObject.name);
                        temphand[handcnt] = loopObject;
                        handcnt += 1;
                    }
                }

                for (int k = handcnt; k < 10; k++)//hand arrayinden geri kalanlarý törpüleyecek
                {
                    temphand[k] = null;
                }

                Debug.Log("HAND1=TEMOPHAND");
                
                for (int l = 0; l < 10; l++)
                {
                    hand1[l] = temphand[l];
                }
                break;

            case 2:
                foreach (GameObject loopObject in hand2)
                {
                    if (loopObject != null/*||!loopObject.Equals(null)*/)
                    {
                        Debug.Log("handcnt is " + handcnt);
                        Debug.Log(loopObject.name);
                        temphand[handcnt] = loopObject;
                        handcnt += 1;
                    }
                }

                for (int k = handcnt; k < 10; k++)//hand arrayinden geri kalanlarý törpüleyecek
                {
                    temphand[k] = null;
                }
                Debug.Log("HAND2=TEMOPHAND");
                for (int l = 0; l < 10; l++)
                {
                    hand2[l] = temphand[l];
                }
                break;


        }
        for (int l = 0; l < 10; l++)
        {
            temphand[l] = null;
        }
    }
}
