using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;
    [SerializeField]
    private string animationName;

    [SerializeField]
    private bool sAttack;
    [SerializeField]
    private float staminaCost;
    [SerializeField]
    private float minAttackMulti;
    [SerializeField]
    private float maxAttackMulti;
    [SerializeField]
    private float minDefenseMulti;
    [SerializeField]
    private float maxDefenseMulti;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;
    private float xStaminaNewScale;
    private Vector2 staminaScale;

    private void Start()
    {
        staminaScale = GameObject.Find("isiStamina1").GetComponent<RectTransform>().localScale;
    }
    public void Attack(GameObject victim)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();

        if(attackerStats.stamina >= staminaCost) 
        {
            float multiplier = Random.Range(minAttackMulti, maxAttackMulti);
            attackerStats.updateStaminaFill(staminaCost);

            damage = multiplier * attackerStats.attack;
            if (sAttack) 
            {
                damage = multiplier * attackerStats.stamina;
                attackerStats.stamina = attackerStats.stamina - staminaCost;
            }
            float defenseMultiplayer = Random.Range(minDefenseMulti, maxDefenseMulti);
            damage = Mathf.Max(0, damage - (defenseMultiplayer * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(damage);
        }
    }
}
