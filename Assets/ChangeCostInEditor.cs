using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ChangeCostInEditor : MonoBehaviour
{

    private void OnGUI()//belki optimize edilebilir?
    {
        GetComponent<Minion>().CardManaCostText.text = GetComponent<Minion>().ManaCost.ToString();
        GetComponent<Minion>().CardAttack.text = GetComponent<Minion>().AttackDamage.ToString();
        GetComponent<Minion>().CardMaxHealth.text = GetComponent<Minion>().health.ToString();
        GetComponent<Minion>().CardAttackRange.text = GetComponent<Minion>().AttackRange.ToString();
    }
}
