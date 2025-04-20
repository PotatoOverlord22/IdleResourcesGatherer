using System;
using Unity.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private CinemachineCamera followCamera;

    private Boolean isWalking;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 forward = followCamera.transform.forward;
        Vector3 right = followCamera.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * inputVector.y + right * inputVector.x;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //isWalking = moveDirection != Vector3.zero;

        //if (isWalking)
        //{
        //    float rotateSpeed = 10f;
        //    transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
        //}
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}