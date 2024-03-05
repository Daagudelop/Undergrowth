using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlanner : MonoBehaviour
{
    //Esta clase sera la encargada de recibir información organizarla y generar un plan a partir de lo que pase en el mundo.
    public static ActionPlanner sharedInstanceActionPlanner;

    //Es singleton
    public List<GameObject> entitiesToTarget = new List<GameObject>();

    private void Awake()
    {
        if (sharedInstanceActionPlanner == null)
        {
            sharedInstanceActionPlanner = this;
        }
    }

    //organiza la lista de prioridades según su daño por segundo.
    public void SortEntitiesToTargetByDPS()
    {
        entitiesToTarget.Clear();
        BattleInfoCollector.sharedInstanceBattleInfoCollector.all.Sort((b, a) => a.GetComponent<EntityStats>().damage.CompareTo(b.GetComponent<EntityStats>().damage));
        entitiesToTarget.AddRange(BattleInfoCollector.sharedInstanceBattleInfoCollector.all);
    }
}
