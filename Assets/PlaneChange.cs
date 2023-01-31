using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneChange : MonoBehaviour
{
    Color originalColor;
    public bool isOnIt;
    private GameManager GameManager;
    private board board;

    public int matrisX;
    public int matrisY;

    public bool canPlayMinion=false;//sadece ilk 4 sýra plane için true

    public bool dontChangeColor=false;//seçim þansý verdiði durumlarda çýkýþý kapatýyor
    public bool isAboutToPlay = false;
    public bool isAboutToAttack = false;
    void Start()
    {
       

        board = GameObject.FindGameObjectWithTag("board").GetComponent<board>();

        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        originalColor = GetComponent<MeshRenderer>().material.color;
        board.boardPlanes[matrisX, matrisY] = gameObject;//biraz x y karýþtý hehe

        if(matrisY==9)
        {
            GameManager.gameObject.GetComponent<EndTurn>().player1PlayablePlanes[matrisX - 1] = gameObject;
        }
        if (matrisY == 1)
        {
            GameManager.gameObject.GetComponent<EndTurn>().player2PlayablePlanes[matrisX - 1] = gameObject;
        }
    }


    private void OnMouseOver()
    {
        if (GameManager.isDevelopingStuff)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            if (GameManager.isHoldingCard && canPlayMinion)
            {
                GetComponent<MeshRenderer>().material.color = Color.green;
            }

            if (isAboutToPlay)
                {
                    GetComponent<MeshRenderer>().material.color = Color.green;
                }

            if (GameManager.isHoldingCard && canPlayMinion==false)
            {
                GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
        
        
    }
    
        private void OnMouseDown()
    {
        if (GameManager.isDevelopingStuff)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else
        {
            if (GameManager.isHoldingCard && canPlayMinion)
            {
                GameManager.PlayActiveCard(matrisX, matrisY, transform.position);
            }

            if(isAboutToPlay)//umarým panele týklandýðýnda buraya girer
            {
                switch (GameManager.HamleMod)
                {
                    case "Move":
                        //if minyon avaliable 

                        StartCoroutine(MoveMinion(GameManager.ActiveMinion.transform,new Vector3(transform.position.x,GameManager.ActiveMinion.transform.position.y,transform.position.z)));
                     
                        GameManager.ActiveMinion.GetComponent<MinionItself>().ClearPanels();
                    break;
                }    
            }
        }
        
    }
    IEnumerator MoveMinion(Transform ActiveMinionTransform,Vector3 HedefPosition)
    {
        ActiveMinionTransform.GetComponent<MinionItself>().xPos = matrisX;
        ActiveMinionTransform.GetComponent<MinionItself>().yPos = matrisY;
        for (float i=1; i<=10; i++)
        {
            ActiveMinionTransform.position = Vector3.Lerp(ActiveMinionTransform.position, HedefPosition, i / 10);

            yield return new WaitForSeconds(0.01f) ;
        }

    }
    private void OnMouseExit()
    {
        if(GameManager.isDevelopingStuff)
        {
            GetComponent<MeshRenderer>().material.color = originalColor;
        }
        else
        {
            if(!dontChangeColor)
            {
                returnOriginal();
            }
            else if(dontChangeColor&&isAboutToPlay)
            {
                GetComponent<MeshRenderer>().material.color = Color.blue;
            }

        }
    }

    public void returnOriginal()
    {
        GetComponent<MeshRenderer>().material.color = originalColor;
        dontChangeColor = false;
        isAboutToPlay = false;
        isAboutToAttack = false;
    }
    
}
