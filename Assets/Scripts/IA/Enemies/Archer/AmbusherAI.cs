using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbusherAI : MonoBehaviour
{
    //test
    public ParticleSystem lucesitasSesis;
    //
    [SerializeField] private EntityStats eStats;
    [SerializeField] private AsignTeam eTeam;
    [SerializeField] private ToRecieveDamage eTakeDamaged;

    private void Start()
    {
        eStats = GetComponent<EntityStats>();
        eTeam = GetComponent<AsignTeam>();
        eTakeDamaged = GetComponent<ToRecieveDamage>();
        ToCreateBehaviourTree();
    }

    private void Update()
    {
        if (eStats.myTurn)
        {
            lucesitasSesis.transform.position = eStats.position1;
            eTakeDamaged.damaged = true;
            Debug.Log("me movi" + gameObject);

            eStats.myTurn = false;
        }
    }
    private void ToCreateBehaviourTree()
    {

    }
}
