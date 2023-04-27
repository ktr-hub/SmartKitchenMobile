using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenCounterSO;
    [SerializeField] public Transform counterTop;
    [SerializeField] private KitchenObject kitchenObject;

    [SerializeField] private bool isTesting;
    [SerializeField] private ClearCounter clearCounter2;

    private void Update()
    {
        if(isTesting && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T pressed");

            if(kitchenObject != null)
            {
                kitchenObject.SetCounter(clearCounter2);
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Interact!");

        Transform kitchenObjectTransform = Instantiate(kitchenCounterSO.kitchenObjectPrefab, counterTop);
        kitchenObjectTransform.localPosition = Vector3.zero;
        kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        //Debug.Log(kitchenObject.GetKitchenObjectSO().objectName);
        //Debug.Log(kitchenCounterSO.objectName);
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
    