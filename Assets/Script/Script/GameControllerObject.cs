using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private List<FighterStats> fighterStats;

    private GameObject battleMenu;

    public TextMeshProUGUI battleText;

    private void Awake()
    {
        battleMenu = GameObject.Find("ActionMenu");
    }

    void Start()
    {
        fighterStats = new List<FighterStats>();

        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats heroStats = hero.GetComponent<FighterStats>();
        heroStats.CalculateNextTurn(0);
        fighterStats.Add(heroStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats enemyStats = enemy.GetComponent<FighterStats>();
        enemyStats.CalculateNextTurn(0);
        fighterStats.Add(enemyStats);

        fighterStats.Sort();

        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);

        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();

            if (currentUnit.tag == "Hero")
            {
                battleMenu.SetActive(true);
            }
            else
            {
                battleMenu.SetActive(false);
                string attackType = Random.Range(0, 2) == 1 ? "melee" : "range";
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);
            }
        }
        else
        {
            NextTurn();
        }
    }

    public void UpdateBattleText(string text)
    {
        battleText.text = text;
        battleText.gameObject.SetActive(true);
    }
}
