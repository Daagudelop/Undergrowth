using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetTrapNode : Node
{
    private EntityStats IA;
    private string effect = "CANNOT RUN!!";

    public FeetTrapNode(EntityStats iA)
    {        
        IA = iA;
    }

    public override NodeState Evaluate()
    {
        if (!IA.Target.GetComponent<EntityStats>().effects.ContainsKey(effect))
        {
            IA.Agility.Play();
            AbilitiesManager.sharedInstanceAbilitiesManager.abilities[0].GetComponent<Ability>().addEffect(IA.Target.GetComponent<EntityStats>());
            AbilitiesManager.sharedInstanceAbilitiesManager.abilities[0].GetComponent<Ability>().EffectOnAgility(IA.Target.GetComponent<EntityStats>(), -2);
            AbilitiesManager.sharedInstanceAbilitiesManager.abilities[0].GetComponent<Ability>().EffectOnChanceToAvoid (IA.Target.GetComponent<EntityStats>(), -2);
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
