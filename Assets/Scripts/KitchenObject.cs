using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private ClearCounter counter; // current parent

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public ClearCounter GetCounter()
    {
        return counter;
    }

    public void SetCounter(ClearCounter counter)
    {
        if(this.counter != null)
            this.counter.ClearKitchenObject();

        this.counter = counter;

        if (counter.HasKitchenObject())
        {
            Debug.LogError("Already has kitchen object");
        }

        counter.SetKitchenObject(this);

        transform.parent = counter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
}
