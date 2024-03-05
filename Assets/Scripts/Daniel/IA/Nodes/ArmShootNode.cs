using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmShootNode : Node
{
    
    private EntityStats IA;

    private string effect = "Weak Arm";

    public ArmShootNode( EntityStats iA)
    {
        this.IA = iA;
    }

    public override NodeState Evaluate()
    {
        if (!IA.Target.GetComponent<EntityStats>().effects.ContainsKey(effect))
        {
            IA.Damage.Play();
            AbilitiesManager.sharedInstanceAbilitiesManager.abilities[2].GetComponent<Ability>().addEffect(IA.Target.GetComponent<EntityStats>());
            AbilitiesManager.sharedInstanceAbilitiesManager.abilities[2].GetComponent<Ability>().EffectOnDamage(IA.Target.GetComponent<EntityStats>(), -2);

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
