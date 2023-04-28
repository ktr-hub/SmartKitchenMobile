using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        Debug.Log("Interact!");
        if (HasKitchenObject())
        {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
    }
}
    