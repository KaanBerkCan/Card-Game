using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperScript : MonoBehaviour
{
    public GameObject DeveloperPanel;
    public void Developerstuff()
    {
        GameManager GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        if (GameManager.isDevelopingStuff)
        {
            DeveloperPanel.SetActive(false);

            GameManager.isDevelopingStuff = false;
            GetComponent<Image>().color = Color.white;
        }

        else
        {
            DeveloperPanel.SetActive(true);
            GameManager.isDevelopingStuff = true;
            GetComponent<Image>().color = Color.blue;
        }


    }
}
