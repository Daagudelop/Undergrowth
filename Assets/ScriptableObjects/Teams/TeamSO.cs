using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Team", menuName = "GameDesign/Team")]
public class TeamSO : ScriptableObject
{
    /*
        Este Scriptable Object hace que el trabajo del GameDesigner sea más facil, 
        solo crea un nuevo equipo y le asigna el Scriptable Object al nuevo personaje.
    */
    [SerializeField] private string newTeam;

    public string NewTeam { get { return newTeam; } }
}
