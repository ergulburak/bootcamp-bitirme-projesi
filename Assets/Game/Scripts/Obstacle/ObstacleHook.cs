using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Obstacle
{
    public class ObstacleHook : MonoBehaviour
    {
        public Transform HookTransform;
        public bool IsLeft;

        public void RunAway()
        {
            transform.DOMoveX(IsLeft ? -30f : 30f, 1f);
        }
    }
}