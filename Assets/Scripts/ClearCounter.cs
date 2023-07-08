using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        Debug.Log("Interact Clear counter!");
        
        //player is carrying kitchen object
        if (player.HasKitchenObject())
        {
            //container is free - Drop
            if(!HasKitchenObject())
                player.GetKitchenObject().SetKitchenObjectParent(this);
        }
        else
        {
            //counter has kitchen object - Pickup
            if (HasKitchenObject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
    