using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 inputVector = gameInput.GetInputVectorNormalised();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * movementSpeed * Time.deltaTime;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime* rotateSpeed);

        isWalking = (moveDir != Vector3.zero);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
