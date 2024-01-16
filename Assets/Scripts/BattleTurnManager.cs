using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleTurnManager : MonoBehaviour
{

    public static BattleTurnManager sharedInstanceBattleTurnManager;
    public List<GameObject> entitiesToFight = new List<GameObject>();
    //public GameObject currentTurnEntity;
    //public GameObject NextTurn;
    private void Awake()
    {
        if (sharedInstanceBattleTurnManager == null)
        {
            sharedInstanceBattleTurnManager = this;
        }
    }

    private void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard.enterKey.wasPressedThisFrame)
        {
            nextTurn();
        }
    }

    public void SortTurnsByAgility()
    {
        entitiesToFight.Clear();
        BattleInfoCollector.sharedInstanceBattleInfoCollector.all.Sort((b, a) => a.GetComponent<EntityStats>().agility.CompareTo(b.GetComponent<EntityStats>().agility));
        entitiesToFight.AddRange(BattleInfoCollector.sharedInstanceBattleInfoCollector.all);
    }

    public void nextTurn()
    {
        if (entitiesToFight.Count == 0)
        {
            SortTurnsByAgility();
            Debug.Log("nani!!, ninguna entidad puede actuar en este turno");
        }
        else
        {
            entitiesToFight[0].GetComponent<EntityStats>().myTurn = true;

            entitiesToFight.RemoveAt(0);
        }
    }

    public void removeFromEntitiesToFight(GameObject gameObject)
    {
        entitiesToFight.Remove(gameObject);
    }
}
