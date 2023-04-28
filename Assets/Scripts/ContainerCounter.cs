using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenCounterSO;


    public override void Interact(Player player)
    {
        Debug.Log("Interact!");
        if (!HasKitchenObject())
        {
            Transform kitchenObjectTransform = Instantiate(kitchenCounterSO.kitchenObjectPrefab, counterTop);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
    }
}
