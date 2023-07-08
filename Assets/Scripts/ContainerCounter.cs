using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenCounterSO;

    public event EventHandler OnPlayerGrabbedObject;


    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            Transform kitchenObjectTransform = Instantiate(kitchenCounterSO.kitchenObjectPrefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        }
    }
}
