using System;
using Game.Scripts.Collectables;
using Game.Scripts.Gates;
using Game.Scripts.MeshChangerSystem;
using Game.Scripts.Obstacle;
using UnityEngine;

namespace Game.Scripts.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerStackManager))]
    public class Player : Singleton<Player> //MonoBehaviour singleton'a çevirdim.
    {
        public bool PlayerCanMove;
        public event EventHandler OnFinish;

        private PlayerMovement _playerMovement => GetComponent<PlayerMovement>();
        private PlayerStackManager _playerStackManager => GetComponent<PlayerStackManager>();
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CollectableBase collectable))
            {
                _playerStackManager.CollectBead(collectable);
            }

            if (other.TryGetComponent(out GateModelChanger gate))
            {
                ModelManager.Instance.FireGateEnterEvent(gate.ModelType);
            }

            if (other.TryGetComponent(out ObstacleBase obstacle))
            {
                _playerStackManager.ThrowBead();
            }
        }
    }
}