using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleField : MonoBehaviour
{
    public int FieldNumber;
    public float distance;  
    public GameObject teamField;
    public List<GameObject> teamFields;

    private void Start()
    {
        teamFields = new List<GameObject>();
        CreateTeamFields(teamField);
    }
    #region Create Team Fields
    private void CreateTeamFields(GameObject teamField)
    {
        float angleOfTheSections = 360 / FieldNumber;

        for (int i = 0; i < FieldNumber; i++)
        {
            Quaternion rotation = Quaternion.AngleAxis(angleOfTheSections * i, Vector3.up) * transform.rotation;
            Vector3 direction = rotation * Vector3.forward;
            Vector3 position = transform.position + direction * distance;
            //
            //EntityTeamsData.sharedInstanceEntityTeamsData.teamsMembers

            //
            teamFields.Add(Instantiate(teamField, position, rotation, transform));
        }
    }
    #endregion
    private void Update()
    {
        
    }
}
