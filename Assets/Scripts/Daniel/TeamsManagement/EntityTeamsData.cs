using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

//Recolets and stores info about the teams on screen

public class EntityTeamsData : MonoBehaviour
{
    //Singleton
    public static EntityTeamsData sharedInstanceEntityTeamsData;

    public SerializedDictionary<string, List<Entity>> teamsMembers;

    Entity[] entities;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (sharedInstanceEntityTeamsData == null)
        {
            sharedInstanceEntityTeamsData = this;
        }
        /*The main reason why strings were selected over enum or something like
        that is because of the use of SO with info for the Game Designer to use
        without touching any line of code.*/
        teamsMembers = new SerializedDictionary<string, List<Entity>>();
    }

    private void Start()
    {
        //Test line.
        RecollectAndAsignTeams();
    }

    private void RecollectAndAsignTeams()
    {
        /*
            The idea is simple, to use a dictionary to store the name of the team and 
            whatever gameobject subtype of Entity Type, and member of a team, They are sorted
            by the same dictionary function containsKey, it will search for your key (the name of the team)
            and will add to the list parented to the key if already exits, else will create a new key, new 
            parented list and will add it to it, that´s why you write the name once on
            a SO, and just drag and drop to the space on the Entity Type.
        */
        entities = GameObject.FindObjectsOfType<Entity>();
        foreach (Entity entity in entities)
        {
            if (teamsMembers.ContainsKey(entity.currentTeam.NewTeam))
            {
                teamsMembers[entity.currentTeam.NewTeam].Add(entity);
            }
            else
            {
                teamsMembers.Add(entity.currentTeam.NewTeam, new List<Entity> { entity });
            }
        }
    }

    private void ReadDictionary()
    {
        foreach (var kvp in teamsMembers)
        {
            Debug.Log($"Clave: {kvp.Key}, Valor: {kvp.Value}");
        }
    }
}