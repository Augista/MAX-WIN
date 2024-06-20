using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class FighterAction : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject monster;
    private GameObject enemy;

    [SerializeField]
    private GameObject simpleAttprefab;

    [SerializeField]
    private GameObject specialAttprefab;

    [SerializeField]
    private Sprite skin;

    private GameObject currentAttack;
    private GameObject simpleAttack;
    private GameObject specialAttack;

    public void SelectAttack(string btn)
    {
        GameObject victim = monster;
        if (tag == "Monster")
        {
            victim = enemy;
        }   
        if (btn.CompareTo("SimpleATT") == 0)
        {
            simpleAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("defense") == 0)
        {
            specialAttack.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            Debug.Log("Run!!!");
        }
    }
}
