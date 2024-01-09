using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInfoCollector : MonoBehaviour
{

    public static BattleInfoCollector sharedInstanceBattleInfoCollector;

    public List<GameObject> enemies;
    public List<GameObject> neutral;
    public List<GameObject> allys;
    public List<GameObject> TeamMates;
    public List<GameObject> Allys;
    public List<GameObject> all;


    private void Awake()
    {
        if (sharedInstanceBattleInfoCollector == null)
        {
            sharedInstanceBattleInfoCollector = this;
        }
    }
}
