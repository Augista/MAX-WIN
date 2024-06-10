using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new Monster")]
public class MonsterBased : ScriptableObject
{
    [SerializeField] string Name;

    [SerializeField] Sprite frontSprite;

    [SerializeField] MonsterType MonsterType;

    [SerializeField] int HP;
    [SerializeField] int ATT;
    [SerializeField] int Energy;
    [SerializeField] int SPATT;


}

public enum MonsterType
{
    Attacker, 
    Defender,
    Balancer,
    BigBoss
}