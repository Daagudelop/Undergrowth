using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSet", menuName = "GameDesign/StatSet")]
public class StatsSO : ScriptableObject
{
    /*
        Este Scriptable Object hace que el trabajo del GameDesigner sea más facil, 
        solo crea un nuevo equipo y le asigna el Scriptable Object al nuevo personaje.
    */
    [SerializeField] private SerializedDictionary<string, int> statsSet;

    public SerializedDictionary<string, int> StatsSet{ get { return statsSet; } }
}
