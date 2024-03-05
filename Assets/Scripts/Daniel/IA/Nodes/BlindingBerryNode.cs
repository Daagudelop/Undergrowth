using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindingBerryNode : Node
{
   
    private EntityStats IA;

    private string effect = "Blinded";

    public BlindingBerryNode( EntityStats iA)
    {
        this.IA = iA;
    }

    public override NodeState Evaluate()
    {
        if (!IA.Target.GetComponent<EntityStats>().effects.ContainsKey(effect))
        {
            IA.Vision.Play();
            AbilitiesManager.sharedInstanceAbilitiesManager.abilities[1].GetComponent<Ability>().addEffect(IA.Target.GetComponent<EntityStats>());
            AbilitiesManager.sharedInstanceAbilitiesManager.abilities[1].GetComponent<Ability>().EffectOnChanceToHit (IA.Target.GetComponent<EntityStats>(), -2);

            IA.actionPoints -= 2;
            IA.myTurn = false;
            IA.isDoingAction = false;
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }

    }
}
