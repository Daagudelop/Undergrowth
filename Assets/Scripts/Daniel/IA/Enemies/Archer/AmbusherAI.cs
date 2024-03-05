using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbusherAI : MonoBehaviour
{

    public GameObject Target;

    public bool isNotInPosition= false; 
    //test
    public ParticleSystem lucesitasSesis;
    
    //
    [SerializeField] private EntityStats eStats;
    [SerializeField] private AsignTeam eTeam;
    [SerializeField] private ToRecieveDamage eTakeDamaged;
    [SerializeField] private Node Behaviour;
    [SerializeField] private Node abilitiesSelector;

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
            transform.position = eStats.BattlepositionIA;
            isNotInPosition = true;
            lucesitasSesis.transform.position = eStats.position1;
            //eTakeDamaged.damaged = true;
            if (!eStats.isDoingAction)
            {
                eStats.isDoingAction = true;
                ActionPlanner.sharedInstanceActionPlanner.SortEntitiesToTargetByDPS();
                Target = ActionPlanner.sharedInstanceActionPlanner.entitiesToTarget[0];
                eStats.Target = Target;
                Behaviour.Evaluate();
                Debug.Log(gameObject + " estoy haciendo algo");
                
            }
            //eStats.myTurn = false;
        }
        else
        {
            if (isNotInPosition)
            {
                Invoke("GoBackToOriginalPosition", 1.3f);
                
                //GoBackToOriginalPosition();
                isNotInPosition = false;
            }
        }
    }

    private void GoBackToOriginalPosition()
    {
        transform.position = eStats.position1;
    }

    private void ToCreateBehaviourTree()
    {
        //Custom Nodes
        APVerifierNode aPverifierNode = new APVerifierNode(eStats);
        FeetTrapNode feetTrapNode = new FeetTrapNode(eStats);
        BlindingBerryNode blindingBerryNode = new BlindingBerryNode( eStats);
        ArmShootNode armShootNode = new ArmShootNode(eStats);
        AmbusherHitNode ambusherHitNode = new AmbusherHitNode(eStats);
        abilitiesSelector = new Selector(new List<Node> { feetTrapNode, blindingBerryNode, armShootNode });

        //Sequences (composites)
        Sequence AbilitiesSequence = new Sequence(new List<Node> { aPverifierNode, abilitiesSelector });

        //Selectors (composites)
        Behaviour = new Selector(new List<Node> { AbilitiesSequence, ambusherHitNode});
    }
}
