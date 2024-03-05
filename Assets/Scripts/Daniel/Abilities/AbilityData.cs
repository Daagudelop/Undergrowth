using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ability data", menuName = "New Ability")]
public class AbilityData : ScriptableObject
{
    [SerializeField] private string abilityName;
    [SerializeField] private string description;
    [SerializeField] private int apCost;
    [SerializeField] private string effect;
    [SerializeField] private int effectTime;
    [SerializeField] private int damage;

    // Getters
    public string AbilityName
    {
        get { return abilityName; }
    }

    public string Description
    {
        get { return description; }
    }

    public int ApCost
    {
        get { return apCost; }
    }
    public string Effect
    {
        get { return effect; }
    }
    public int EffectTime
    {
        get { return effectTime; }
    }
    public int Damage
    {
        get { return damage; }
    }
}

