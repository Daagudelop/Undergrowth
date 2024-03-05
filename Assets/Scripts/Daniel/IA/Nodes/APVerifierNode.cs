using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APVerifierNode : Node
{
    private EntityStats eStats;

    public APVerifierNode(EntityStats eStats)
    {
        this.eStats = eStats;
    }
    public override NodeState Evaluate()
    {
        return eStats.actionPoints > 0 ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
