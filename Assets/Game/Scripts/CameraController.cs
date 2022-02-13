using System;
using Cinemachine;
using UnityEngine;

namespace Game.Scripts
{
    public class CameraController : Singleton<Level>
    {
        [SerializeField] private Transform finishTarget;

        private Player.Player _player => FindObjectOfType<Player.Player>();
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;


        private void Start()
        {
            _player.OnFinish += FireOnFinish;
        }

        private void FireOnFinish(object sender, EventArgs e)
        {
            //cinemachineVirtualCamera.Follow = finishTarget;
            cinemachineVirtualCamera.LookAt = finishTarget;
        }
    }
}