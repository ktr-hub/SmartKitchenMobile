using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenCounterSO;
    [SerializeField] public Transform counterTop;
    private KitchenObject kitchenObject;

    [SerializeField] private bool isTesting;
    [SerializeField] private ClearCounter clearCounter2;

    private void Update()
    {
        if(isTesting && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T pressed");

            if(kitchenObject != null)
            {
                kitchenObject.SetKitchenObjectParent(clearCounter2);
            }
        }
    }

    public void Interact(Player player)
    {
        Debug.Log("Interact!");
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenCounterSO.kitchenObjectPrefab, counterTop);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTop.transform;
    }
}
    