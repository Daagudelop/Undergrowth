using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbusherHitNode : Node
{
    private EntityStats IA;


    public AmbusherHitNode( EntityStats iA)
    {
        this.IA = iA;
    }

    public override NodeState Evaluate()
    {
        AbilitiesManager.sharedInstanceAbilitiesManager.abilities[3].GetComponent<Ability>().DoDamage(IA.Target.GetComponent<EntityStats>());
        IA.myTurn = false;
        IA.isDoingAction = false;

        return NodeState.SUCCESS;        
    }
}
