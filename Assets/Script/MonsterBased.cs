using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new Monster")]
public class MonsterBased : ScriptableObject
{
    [SerializeField] string name;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] MonsterType type1;
    [SerializeField] MonsterType type2;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int energy;
    [SerializeField] int spAttack;


}

public enum MonsterType
{ 
    Beezord,
    Vulcan,
    Hades,
    DeezNut
}