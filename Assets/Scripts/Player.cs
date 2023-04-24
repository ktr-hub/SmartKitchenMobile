using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event EventHandler<OnSelectedCounterEventArgs> OnSelectedCounter;

    public class OnSelectedCounterEventArgs
    {
        public ClearCounter selectedCounter;
    }

    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
    
    private ClearCounter selectedCounter;

    private Vector3 lastInteractDir;

    private bool isWalking;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There are more than one Player instances");
        }
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        gameInput.OnInteractPerformed += GameInput_OnInteractPerformed;
    }

    private void GameInput_OnInteractPerformed(object sender, EventArgs e)
    {
        if(selectedCounter != null)
        {
            Debug.Log("Pressed Interact Key");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        float interactionDistance = 2f;
        Vector2 inputVector = gameInput.GetInputVectorNormalised();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero)
            lastInteractDir = moveDir;

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit clearCounterCollided, interactionDistance, countersLayerMask))
        {
            if (clearCounterCollided.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                SelectCounter(clearCounter);
            }
            else
            {
                SelectCounter(null);
            }
        }
        else
        {
            SelectCounter(null);
        }
    }

    private void Player_OnSelectedCounter(object sender, OnSelectedCounterEventArgs e)
    {
        e.selectedCounter = selectedCounter;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetInputVectorNormalised();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        float moveDistance = movementSpeed * Time.deltaTime;

        float playerSize = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDir, moveDistance);

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        else
        {
            //if player can move only in X
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDirX, moveDistance);

            if (canMove)
            {
                transform.position += moveDirX * moveDistance;
            }
            else
            {
                //if player can move only in Z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDirZ, moveDistance);

                if (canMove)
                {
                    transform.position += moveDirZ * moveDistance;
                }
            }
        }

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

        isWalking = (moveDir != Vector3.zero);
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void SelectCounter(ClearCounter clearCounter)
    {
        selectedCounter = clearCounter;
        OnSelectedCounter += Player_OnSelectedCounter;
        OnSelectedCounter.Invoke(this,new OnSelectedCounterEventArgs { selectedCounter = selectedCounter });
    }
}
