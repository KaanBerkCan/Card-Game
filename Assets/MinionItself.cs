using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MinionItself : MonoBehaviour
{

    private GameManager GameManager;
    [HideInInspector]
    public int CurrentAP, MaxAP, Maxhealth, movement,AttackRange,AttackDamage;
    float currentHealth;
    public GameObject minionPanel;

    [HideInInspector]
    public int xPos, yPos;
    board board;

    public int MinionPlayerNumber;
    public TMP_Text healthtext;

    public GameObject SpotLight;
    void Start()
    {
        currentHealth = Maxhealth;
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        CurrentAP = MaxAP;
        board = GameObject.FindGameObjectWithTag("board").GetComponent<board>();
        UpdateHealth();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)||Input.GetMouseButton(2))
        {
            ClearPanels();
            
        }
    }
    public void MoveMinion()//girince paneli kapat 
    {
        GameManager.HamleMod = "Move";
        GameManager.ActiveMinion = this.gameObject;
        minionPanel.SetActive(false);
    
        //moveable kareler mavi yancak
        for (int i = 1; i <= movement; i++)
        {   
            if (yPos + i <= 9)//arrayin dýþýna çýkmasýn diye
            {
                board.boardPlanes[xPos, yPos + i].GetComponent<MeshRenderer>().material.color = Color.blue;
                board.boardPlanes[xPos, yPos + i].GetComponent<PlaneChange>().dontChangeColor = true;
                board.boardPlanes[xPos, yPos + i].GetComponent<PlaneChange>().isAboutToPlay = true;
            }
            if (xPos + i <= 9)
            {
                board.boardPlanes[xPos + i, yPos].GetComponent<MeshRenderer>().material.color = Color.blue;
                board.boardPlanes[xPos + i, yPos].GetComponent<PlaneChange>().dontChangeColor = true;
                board.boardPlanes[xPos + i, yPos].GetComponent<PlaneChange>().isAboutToPlay = true;
            }
            if (yPos - i >= 1)
            {
                board.boardPlanes[xPos, yPos - i].GetComponent<MeshRenderer>().material.color = Color.blue;
                board.boardPlanes[xPos, yPos - i].GetComponent<PlaneChange>().dontChangeColor = true;
                board.boardPlanes[xPos, yPos - i].GetComponent<PlaneChange>().isAboutToPlay = true;
            }
            if (xPos - i >= 1)
            {
                board.boardPlanes[xPos - i, yPos].GetComponent<MeshRenderer>().material.color = Color.blue;
                board.boardPlanes[xPos - i, yPos].GetComponent<PlaneChange>().dontChangeColor = true;
                board.boardPlanes[xPos - i, yPos].GetComponent<PlaneChange>().isAboutToPlay = true;
            }
        }
    }

    public void AttackMinion()
    {
        GameManager.HamleMod = "Attack";
        GameManager.ActiveMinion = this.gameObject;
        minionPanel.SetActive(false);

        board.boardPlanes[xPos, yPos].GetComponent<MeshRenderer>().material.color = Color.red;
        board.boardPlanes[xPos, yPos].GetComponent<PlaneChange>().dontChangeColor = true;
        board.boardPlanes[xPos, yPos].GetComponent<PlaneChange>().isAboutToAttack = true;

        //attack menzilindeki kareler kýrmýzý yancak
        for (int i = 1; i <= AttackRange; i++)
        {
            if (yPos + i <= 9)//arrayin dýþýna çýkmasýn diye
            {
                board.boardPlanes[xPos, yPos + i].GetComponent<MeshRenderer>().material.color = Color.red;
                board.boardPlanes[xPos, yPos + i].GetComponent<PlaneChange>().dontChangeColor = true;
                board.boardPlanes[xPos, yPos + i].GetComponent<PlaneChange>().isAboutToAttack = true;
            }
            if (xPos + i <= 9)
            {
                board.boardPlanes[xPos + i, yPos].GetComponent<MeshRenderer>().material.color = Color.red;
                board.boardPlanes[xPos + i, yPos].GetComponent<PlaneChange>().dontChangeColor = true;
                board.boardPlanes[xPos + i, yPos].GetComponent<PlaneChange>().isAboutToAttack = true;
            }
            if (yPos - i >= 1)
            {
                board.boardPlanes[xPos, yPos - i].GetComponent<MeshRenderer>().material.color = Color.red;
                board.boardPlanes[xPos, yPos - i].GetComponent<PlaneChange>().dontChangeColor = true;
                board.boardPlanes[xPos, yPos - i].GetComponent<PlaneChange>().isAboutToAttack = true;
            }
            if (xPos - i >= 1)
            {
                board.boardPlanes[xPos - i, yPos].GetComponent<MeshRenderer>().material.color = Color.red;
                board.boardPlanes[xPos - i, yPos].GetComponent<PlaneChange>().dontChangeColor = true;
                board.boardPlanes[xPos - i, yPos].GetComponent<PlaneChange>().isAboutToAttack = true;
            }
        }
    }


    public void ClearPanels()
    {
        GameManager.HamleMod = "";
        GameManager.ActiveMinion = null;
        GameManager.ActiveCard = null;//hata yaratabilir
        minionPanel.SetActive(false);
        board.goBack();//renkleri temizler
    }
    
    private void OnMouseDown()
    {
        if (MinionPlayerNumber==GameManager.PlayerNumTurn&&!board.boardPlanes[xPos, yPos].GetComponent<PlaneChange>().isAboutToAttack)
        {
            ClearPanels();
            minionPanel.SetActive(true);
        }
        else if(board.boardPlanes[xPos, yPos].GetComponent<PlaneChange>().isAboutToAttack)//hasar yer
        {
            float damage = GameManager.ActiveMinion.GetComponent<MinionItself>().AttackDamage;
            currentHealth -= damage;
            UpdateHealth();
            ClearPanels();
            Debug.Log(currentHealth);
        }
    }
    private void OnMouseOver()
    {
        if(board.boardPlanes[xPos, yPos].GetComponent<PlaneChange>().isAboutToAttack)
        {
            SpotLight.SetActive(true);
        }
        
        
    }
    private void OnMouseExit()
    {
        SpotLight.SetActive(false);

    }
    //IEnumerator checkifmouseOver()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    if(OnMouseOver)
    //    {

    //    }
    //}
    public void UpdateHealth()
    {
        healthtext.text = currentHealth.ToString();
        if (currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }
    
}
