using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")] [SerializeField] [Range(10f, 150f)]
    private float swerveSpeed;

    [SerializeField] [Range(0.005f, 0.05f)]
    private float minDistanceToMove;

    [SerializeField] private float xBound;

    [SerializeField] private float minSwerveDistance;

    [SerializeField] private Transform playerPivot;

    [SerializeField] private float forwardSpeed;

    private Vector2 touchEventArgs = Vector2.zero;

    public void MoveForward()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }

    public void MoveHorizontal(Vector2 args)
    {
        var distance = Vector2.Distance(args, touchEventArgs);

        if (distance < minSwerveDistance) return;

        var position = args;
        var playerPivotPosition = playerPivot.localPosition;

        if (playerPivotPosition.x <= xBound && position.x > touchEventArgs.x)
        {
            playerPivotPosition = Vector3.MoveTowards(playerPivotPosition,
                new Vector3(playerPivotPosition.x + minDistanceToMove * distance,
                    playerPivotPosition.y, playerPivotPosition.z),
                Time.fixedDeltaTime * swerveSpeed);
            if (playerPivotPosition.x > xBound)
                playerPivotPosition = new Vector3(xBound, playerPivotPosition.y, playerPivotPosition.z);
        }

        if (playerPivotPosition.x >= -xBound && position.x < touchEventArgs.x)
        {
            playerPivotPosition = Vector3.MoveTowards(playerPivotPosition,
                new Vector3(playerPivotPosition.x - minDistanceToMove * distance,
                    playerPivotPosition.y, playerPivotPosition.z),
                Time.fixedDeltaTime * swerveSpeed);

            if (playerPivotPosition.x < -xBound)
                playerPivotPosition = new Vector3(-xBound, playerPivotPosition.y, playerPivotPosition.z);
        }

        playerPivot.localPosition = playerPivotPosition;
        touchEventArgs = args;
    }
}