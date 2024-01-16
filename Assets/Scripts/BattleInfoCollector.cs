using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInfoCollector : MonoBehaviour
{

    public static BattleInfoCollector sharedInstanceBattleInfoCollector;

    public List<GameObject> enemies;
    public List<GameObject> neutral;
    public List<GameObject> allys;
    public List<GameObject> teamMates;
    public List<GameObject> infected;
    public List<GameObject> all;


    private void Awake()
    {
        if (sharedInstanceBattleInfoCollector == null)
        {
            sharedInstanceBattleInfoCollector = this;
        }
        enemies = new List<GameObject>();
        neutral = new List<GameObject>();
        allys = new List<GameObject>();
        teamMates = new List<GameObject>();
        infected = new List<GameObject>();
        all = new List<GameObject>();
    }

    public void addAlly(GameObject gameObject)
    {
        allys.Add(gameObject);
    }
    public void addEnemy(GameObject gameObject)
    {
        enemies.Add(gameObject);
    }
    public void addNeutral(GameObject gameObject)
    {
        neutral.Add(gameObject);
    }
    public void addTeamMate(GameObject gameObject)
    {
        teamMates.Add(gameObject);
    }
    public void addInfected(GameObject gameObject)
    {
        infected.Add(gameObject);
    }
    public void addtoAll(GameObject gameObject)
    {
        all.Add(gameObject);
    }

    public void removeAlly(GameObject gameObject)
    {
        allys.Remove(gameObject);
    }
    public void removeEnemy(GameObject gameObject)
    {
        enemies.Remove(gameObject);
    }
    public void removeNeutral(GameObject gameObject)
    {
        neutral.Remove(gameObject);
    }
    public void removeTeamMate(GameObject gameObject)
    {
        teamMates.Remove(gameObject);
    }
    public void removeInfected(GameObject gameObject)
    {
        infected.Remove(gameObject);
    }
    public void removeFromAll(GameObject gameObject)
    {
        all.Remove(gameObject);
    }
}
