using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public int MaxMana;
    public int CurrentMana;
    public Text ManaText;
    public Text ManaText2;


    public bool isHoldingCard=false;
    public GameObject ActiveCard;
    public GameObject ActiveMinion;

    [HideInInspector]
    public bool isDevelopingStuff=false;


    public string HamleMod;
    [HideInInspector]
    public int PlayerNumTurn=1;
    void Start()
    {
        Application.targetFrameRate = 60;
        PlayerNumTurn = 1;
        MaxMana = PlayerPrefs.GetInt("UsableMana", 10);
        CurrentMana = MaxMana;
    }

   
    public void UseMana(int cost)
    {    
        switch(PlayerNumTurn)
        {
            case 1:
                CurrentMana -= cost;
                ManaText.text = CurrentMana + "/" + MaxMana;
                break;

            case 2:
                CurrentMana -= cost;
                ManaText2.text = CurrentMana + "/" + MaxMana;
                break;
        }    
       
    }

    

    public void PlayActiveCard(int x,int y,Vector3 pos)
    {
        ActiveCard.GetComponent<Minion>().UseCard(x,y,pos);
    }

    

    
    
}
