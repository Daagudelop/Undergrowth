using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    public static AbilitiesManager sharedInstanceAbilitiesManager;

    public List<GameObject> abilities;

    private void Awake()
    {
        if (sharedInstanceAbilitiesManager == null)
        {
            sharedInstanceAbilitiesManager = this;
        }
    }

}
