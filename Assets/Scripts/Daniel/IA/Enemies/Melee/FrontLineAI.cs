using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontLineAI : MonoBehaviour
{
    //test
    public ParticleSystem lucesitasSesis;
    //
    [SerializeField] private EntityStats eStats;
    [SerializeField] private AsignTeam eTeam;

    private void Start()
    {
        eStats = GetComponent<EntityStats>();
        eTeam = GetComponent<AsignTeam>();
        ToCreateBehaviourTree();
    }

    private void Update()
    {
        if (eStats.myTurn)
        {
            lucesitasSesis.transform.position = eStats.position1;
            Debug.Log("me movi" + gameObject);
            eStats.myTurn = false;  
        }
    }
    private void ToCreateBehaviourTree()
    {

    }
}
