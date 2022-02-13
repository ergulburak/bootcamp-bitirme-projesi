using System;
using UnityEngine;

namespace Game.Scripts
{
    public class Level : Singleton<Level>
    {
        private Player.Player _player => FindObjectOfType<Player.Player>();

        private void Start()
        {
            _player.OnFinish += FireOnFinish;
        }

        private void FireOnFinish(object sender, EventArgs e)
        {
            gameObject.SetActive(false);
        }
    }
}