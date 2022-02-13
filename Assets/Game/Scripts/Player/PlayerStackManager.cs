using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.Scripts.Collectables;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerStackManager : MonoBehaviour
    {
        [Header("Stack Settings")] [SerializeField]
        private List<Transform> stackPoints = new List<Transform>();

        [SerializeField] private float collectDuration;


        private List<Transform> filledStackPoints = new List<Transform>();

        public void CollectBead(CollectableBase collectable)
        {
            if (stackPoints.Count <= 0) return;

            var collectableTransform = collectable.transform;
            var transformPoint = stackPoints.First();

            collectableTransform.SetParent(transformPoint);

            //var collectableCollider = collectable.GetComponent<Collider>();
            //collectableCollider.enabled = false;

            stackPoints.Remove(transformPoint);
            filledStackPoints.Add(transformPoint);
            collectableTransform.DOLocalMove(Vector3.zero, collectDuration);
            collectableTransform.DOLocalRotate(Vector3.zero, collectDuration);
        }
    }
}