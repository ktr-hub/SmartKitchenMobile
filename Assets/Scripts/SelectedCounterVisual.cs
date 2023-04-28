using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter selectedCounter;
    [SerializeField] private GameObject[] counterVisualObjectsArray;
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
        foreach (var item in counterVisualObjectsArray)
        {
            item.SetActive(false);
        }
    }

    private void Show()
    {
        foreach (var item in counterVisualObjectsArray)
        {
            item.SetActive(true);
        }
    }
}
