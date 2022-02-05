using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public bool PlayerCanMove;
    public event EventHandler OnFinish;
    
    private PlayerMovement _playerMovement => GetComponent<PlayerMovement>();
    private bool onFirstClick = true;

    private void Awake()
    {
        InputManager.Instance.OnClick += OnFirstClick;
        InputManager.Instance.OnSwerve += OnSwerve;
    }

    private void Update()
    {
        if (PlayerCanMove)
        {
            _playerMovement.MoveForward();
        }
    }

    public void OnWin()
    {
        OnFinish?.Invoke(this, EventArgs.Empty);
    }

    public float GetPlayerZPosition()
    {
        return transform.position.z;
    }

    private void OnSwerve(object sender, Vector2 e)
    {
        if (PlayerCanMove)
            _playerMovement.MoveHorizontal(e);
    }

    private void OnFirstClick(object sender, bool e)
    {
        if (onFirstClick)
        {
            onFirstClick = false;
            PlayerCanMove = !PlayerCanMove;
        }
    }
}