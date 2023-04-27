using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter selectedCounter;
    [SerializeField] private GameObject counterVisualObject;
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.OnSelectedCounter += Player_OnSelectedCounter;
    }

    private void Player_OnSelectedCounter(object sender, Player.OnSelectedCounterEventArgs e)
    {
        if(e.selectedCounter != null && e.selectedCounter == selectedCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        counterVisualObject.SetActive(false);
    }

    private void Show()
    {
        counterVisualObject.SetActive(true);
    }
}
