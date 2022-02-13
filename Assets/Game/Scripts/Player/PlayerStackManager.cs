using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.Scripts.Collectables;
using Game.Scripts.Obstacle;
using Sirenix.Utilities;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerStackManager : MonoBehaviour
    {
        [Header("Stack Settings")] [SerializeField]
        private List<Transform> stackPoints = new List<Transform>();

        [SerializeField] private float collectDuration;

        private Dictionary<Transform, CollectableBase> filledPoints = new Dictionary<Transform, CollectableBase>();

        public void CollectBead(CollectableBase collectable)
        {
            if (stackPoints.Count <= 0) return;

            var collectableTransform = collectable.transform;
            var transformPoint = stackPoints.First();

            collectableTransform.SetParent(transformPoint);

            //var collectableCollider = collectable.GetComponent<Collider>();
            //collectableCollider.enabled = false;

            stackPoints.Remove(transformPoint);
            filledPoints.Add(transformPoint, collectable);
            collectableTransform.DOLocalMove(Vector3.zero, collectDuration);
            collectableTransform.DOLocalRotate(Vector3.zero, collectDuration);
        }

        public void ThrowBead()
        {
            var collectable = filledPoints.First();

            stackPoints.Insert(0, collectable.Key);
            filledPoints.Remove(collectable.Key);

            var targetCollectableTransform = collectable.Value.transform;
            targetCollectableTransform.parent = null;
            targetCollectableTransform.DOMoveY(8f, 1f).OnComplete(() =>
            {
                Destroy(targetCollectableTransform.gameObject);
            });
        }

        public void StealBead(ObstacleHook obstacleHook)
        {
            var collectable = filledPoints.First();

            stackPoints.Insert(0, collectable.Key);
            filledPoints.Remove(collectable.Key);

            var targetCollectableTransform = collectable.Value.transform;
            var targetTransform = obstacleHook.HookTransform;

            targetCollectableTransform.parent = targetTransform;
            targetCollectableTransform.DOLocalMove(Vector3.zero, 0.2f).OnComplete(obstacleHook.RunAway);
        }
    }
}