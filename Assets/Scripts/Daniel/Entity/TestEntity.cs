using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEntity : Entity
{


    #region Readers
    private void ReadDictionary()
    {
        foreach (var kvp in statsSet)
        {
            Debug.Log($"Clave: {kvp.Key}, Valor: {kvp.Value}");
        }
    }
    #endregion
}
