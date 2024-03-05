using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    //Our enemies must not be SO since its stats may change during time, not exclusively inBattle or Exploring due to the rpg-openworld game we are creating, in the matter of the fact players gonna save the game during those game states we will need to save whatever happen to this entities, prefabs is our only option, besides that the number of entities in screen will no be insane, over 10 even a little bit more, not the thousands on other kind of games. Prefabs is the best option. not the same for habilities, weapons, etc, those are gonna be SO.

    public bool myTurn = false;
    public bool effectOnMe = false;
    public bool isDoingAction = false;
    public GameObject Target;

    [Header("Effects")]
    public Dictionary<string, int> effects = new Dictionary<string, int>();

    [Header("Attributes")]
    public int agility ;
    public int actionPoints ;
    public int coldown ;
    public int life;
    public int resistance;
    public int chanceToHit = 8;
    public int chanceToAvoid;
    public int damage;


    [Header("Position Order")]
    public int position;
    public Vector3 position1;
    public Vector3 BattlepositionIA; 
    public Vector3 BattlepositionTeamMate;
    public ParticleSystem Agility;
    public ParticleSystem Vision;
    public ParticleSystem Damage;

    private void Start()
    {
        chanceToAvoid = (agility*10) / 3;
    }

    private void Awake()
    {
        position1 = this.gameObject.transform.position;
        BattlepositionIA = GameObject.FindWithTag("IAPos").transform.position;
        BattlepositionTeamMate = GameObject.FindWithTag("AllyPos").transform.position;
    }

    private void Update()
    {
        if (effectOnMe)
        {

            // Recorrer todos los elementos del diccionario
            List<string> keys = new List<string>(effects.Keys);
            foreach (string key in keys)
            {
                // Disminuir el valor en 1
                effects[key]--;
            }

            // Restablecer el bool a false
            effectOnMe = false;
        }

        if (life <= 0)
        {
            Destroy(this);
        }
    }
}
