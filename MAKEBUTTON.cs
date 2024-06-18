using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class MAKEBUTTON : MonoBehaviour
{
    [SerializeField]
    private bool physical;
    private GameObject monster;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        monster = GameObject.FindGameObjectWithTag("Monster");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("AttackBtn") == 0)
        {
            monster.GetComponent<FighterAction>().SelectAttack("SimpleATT");
        }else if (btn.CompareTo("DefenseBtn")==0) 
        {
            monster.GetComponent<FighterAction>().SelectAttack("defense");
        }else
        {
            monster.GetComponent<FighterAction>().SelectAttack("run");
        }

    }
}
