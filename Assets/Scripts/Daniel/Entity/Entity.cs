using AYellowpaper.SerializedCollections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public TeamSO currentTeam;
    public StatsSO stats;

    /*[SerializeField]*/
    public SerializedDictionary<string, int> statsSet;

    private void Start()
    {
        toInmutableDataDictionary();
    }

    #region SO data to Inmutable data

    private void toInmutableDataDictionary()
    {
        statsSet = new SerializedDictionary<string, int>();
        foreach (var kvp in stats.StatsSet)
        {
            statsSet.Add(kvp.Key, kvp.Value);
        }
    }

    #endregion

    #region Unused
    /*
        This method will add the stats as easier usable data on a dictionary of stats,
        It will split the string in StatName and StatValue so it will add it as intended
        to the  dictionary.
    */
    /*public void AddBaseStats(Dictionary<string, int> stats)
    {
        char delimiter = ',';
        string[] statAndStatValue;
        foreach (var stat in Stats.StatNames)
        {
            statAndStatValue = stat.Split(delimiter);
            //Debug.Log(statAndStatValue[0] + " "+statAndStatValue[1]);
            foreach (var statOrStatValue in statAndStatValue)
            {
                //Si el string puede ser un int entonces que se añada al nombre del stat.
                if (int.TryParse(statOrStatValue, out int StatValue))
                {
                    stats[statAndStatValue[0]] = int.Parse(statOrStatValue);
                }
                //De lo contrario se añadira un nuevo key de valor 0
                else
                {
                    stats.Add(statOrStatValue, 0);
                }
            }
        }
    }*/
    #endregion
}
