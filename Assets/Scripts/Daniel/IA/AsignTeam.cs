using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Team
{
    enemy,
        neutral,
        teamMate,
        ally,
        infected,
        custom,
    }

public class AsignTeam : MonoBehaviour
{

    [SerializeField] public Team currentTeam ;
    public bool remove = false;
    public bool toAdd = false;
    private void Awake()
    {

    }
    private void Start()
    {
        if (toAdd)
        {
            SetTeam(currentTeam);
            toAdd = false;
        }
    }
    private void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard.aKey.wasPressedThisFrame)
        {
            removeFromLists();
        }
    }
    private void OnEnable()
    {
        //simple verifier since sync might fail eventually at the first launch due to OnEnable´s execution time almost the same of Awake.
        if (BattleInfoCollector.sharedInstanceBattleInfoCollector ==  null)
        {
            toAdd = true;
        }
        else
        {
            SetTeam(currentTeam);
        }
    }

    private void OnDisable()
    {
        removeFromLists();

    }

    private void OnDestroy()
    {
        removeFromLists();
    }

    public void removeFromLists()
    {
        remove = true;
        SetTeam(currentTeam);
        BattleTurnManager.sharedInstanceBattleTurnManager.removeFromEntitiesToFight(this.gameObject);
        remove = false;
    }

    public void toEnemyTeam()
    {
        SetTeam(Team.enemy);
    }

    public void toNeutralTeam()
    {
        SetTeam(Team.neutral);
    }   

    public void toAllyTeam()
    {
        SetTeam(Team.ally);
    }

    public void toInfectedTeam()
    {
        SetTeam(Team.infected);
    }

    public void toCustomTeam()
    {
        SetTeam(Team.custom);
    }

    public void notATeamMemberAnymore ()
    {

    }

    public void SetTeam(Team newTeam)
    {
        if (BattleInfoCollector.sharedInstanceBattleInfoCollector == null)
        {
            
        }
        else
        {

            if (newTeam == Team.enemy)
            {
                if (remove)
                {
                    BattleInfoCollector.sharedInstanceBattleInfoCollector.removeEnemy(this.gameObject);
                    Debug.Log("removed");
                }
                else if (!remove)
                {
                    BattleInfoCollector.sharedInstanceBattleInfoCollector.addEnemy(this.gameObject);
                    Debug.Log("enemyTeam");
                }
            
            }
            else if (newTeam == Team.neutral)
            {
                if (remove)
                {
                    BattleInfoCollector.sharedInstanceBattleInfoCollector.removeNeutral(this.gameObject);
                    Debug.Log("removed");
                }
                else if (!remove)
                {
                    BattleInfoCollector.sharedInstanceBattleInfoCollector.addNeutral(this.gameObject);
                    Debug.Log("nTeam");
                }
            }
            else if (newTeam == Team.ally)
            {
                if (remove)
                {
                    BattleInfoCollector.sharedInstanceBattleInfoCollector.removeAlly(this.gameObject);
                    Debug.Log("removed");
                }
                else if (!remove)
                {
                    BattleInfoCollector.sharedInstanceBattleInfoCollector.addAlly(this.gameObject);
                    Debug.Log("aTeam");
                }
            }
            else if (newTeam == Team.infected)
            {
                if (remove)
                {
                    BattleInfoCollector.sharedInstanceBattleInfoCollector.removeInfected(this.gameObject);
                    Debug.Log("removed");
                }
                else if (!remove)
                {
                    BattleInfoCollector.sharedInstanceBattleInfoCollector.addInfected(this.gameObject);
                    Debug.Log("iTeam");
                }
            }
            else if (newTeam == Team.custom)
            {
                if (remove)
                {

                }
                else if (!remove)
                {
                    Debug.Log("custom");
                }
            }
        }
        if (remove)
        {
            BattleInfoCollector.sharedInstanceBattleInfoCollector.removeFromAll(this.gameObject);
        }
        else
        {
            BattleInfoCollector.sharedInstanceBattleInfoCollector.addtoAll(this.gameObject);
            this.currentTeam = newTeam;
        }
    }

}
