using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private AbilityData AbilityData;

    public void addEffect(EntityStats Target) 
    {
        Target.effects.Add(AbilityData.Effect,AbilityData.EffectTime);
    }

    public void removeEffect(EntityStats Target)
    {

    }

    public void DoDamage(EntityStats Target)
    {
        Target.life += AbilityData.Damage;
    }

    public void EffectOnAgility(EntityStats Target, int effect)
    {
        Target.agility += effect;
    }
    public void EffectOnChanceToHit(EntityStats Target, int effect)
    {
        Target.chanceToHit += effect;
    }

    public void EffectOnChanceToAvoid(EntityStats Target, int effect)
    {
        Target.chanceToAvoid += effect;
    }

    public void EffectOnDamage(EntityStats Target, int effect)
    {
        Target.damage += effect;
    }
}
