using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Minion : MonoBehaviour
{
    public int ManaCost;
    public Text CardManaCostText,CardAttack, CardAttackRange,CardMaxHealth;
    public int MaxAP=1;

    public int movement,health, AttackRange, AttackDamage;
    private GameManager GameManager;
    private DeckHolder DeckHolder;

    RectTransform m_RectTransform;
    

    public GameObject minionPrefab;

    public int MinionPlayerNumber;//hangi oyuncunun sahip olduðuna göre deðiþmesi lazým

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        DeckHolder = GameObject.FindGameObjectWithTag("GameController").GetComponent<DeckHolder>();
        m_RectTransform = GetComponent<RectTransform>();
    }
    

    public void ChooseCard()
    {
        if (GameManager.CurrentMana>=ManaCost&& GameManager.isHoldingCard==false)
        {
            
            StartCoroutine(FollowMouse());
            GameManager.isHoldingCard = true;
            GameManager.ActiveCard = this.gameObject;
        }
        else
        {
            
        }
    }
    IEnumerator FollowMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x -=Screen.width/2 ;
        m_RectTransform.anchoredPosition = Vector2.Lerp(m_RectTransform.anchoredPosition, mousePosition, 0.25f);

        yield return new WaitForSeconds(0.01f);  

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopCoroutine(FollowMouse());
            GameManager.isHoldingCard = false;
            DeckHolder.CardPositions();
        }
        else
        {
            StartCoroutine(FollowMouse());
        }
    }

    public void UseCard(int x, int y, Vector3 pos)
    {
        GameManager.UseMana(ManaCost);
        //if minyon
        pos.y += 2;

        minionPrefab.GetComponent<MinionItself>().MaxAP = MaxAP;
        minionPrefab.GetComponent<MinionItself>().xPos = x;
        minionPrefab.GetComponent<MinionItself>().yPos = y;
        minionPrefab.GetComponent<MinionItself>().Maxhealth = health;
        minionPrefab.GetComponent<MinionItself>().movement = movement;
        minionPrefab.GetComponent<MinionItself>().AttackRange = AttackRange;
        minionPrefab.GetComponent<MinionItself>().AttackDamage = AttackDamage; 
        minionPrefab.GetComponent<MinionItself>().MinionPlayerNumber = MinionPlayerNumber;


        float rotasyon = (GameManager.PlayerNumTurn - 1) * 180;//eðer 1. playerse 0, 2. playerse 180
        Instantiate(minionPrefab, pos, new Quaternion(0, rotasyon, 0,0));
        DestroyImmediate(gameObject);

        //gameObject.SetActive(false);
        GameManager.isHoldingCard = false;
        DeckHolder.CardPositions();
      
        
    }

    
   

    
}
