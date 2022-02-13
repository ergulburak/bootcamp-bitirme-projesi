using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.MeshChangerSystem;
using Sirenix.Utilities;
using UnityEngine;

namespace Game.Scripts.Collectables
{
    public class CollectableBase : MonoBehaviour
    {
        [SerializeField] private List<CollectableModelSet> collectableModelSets = new List<CollectableModelSet>();
        [SerializeField] private CollectableModelSet activeModelSet;
        [SerializeField] private BeadType activeBeadLevel = BeadType.Low;

        private void Start()
        {
            if (activeModelSet == null) activeModelSet = collectableModelSets.First();

            collectableModelSets.ForEach(x =>
            {
                x.gameObject.SetActive(false);

                if (x.Type != activeModelSet.Type) return;

                x.gameObject.SetActive(true);
                ChangeModel(activeBeadLevel);
            });
        }

        private void OnEnable()
        {
            ModelManager.Instance.OnGateEnterEvent += ChangeModelSet;
        }

        private void OnDisable()
        {
            ModelManager.Instance.OnGateEnterEvent -= ChangeModelSet;
        }

        public BeadType GetBeadLevel()
        {
            return activeBeadLevel;
        }

        private void ChangeModelSet(object sender, ModelType e)
        {
            foreach (var modelSet in collectableModelSets)
            {
                modelSet.gameObject.SetActive(false);
                if (!modelSet.Type.Equals(e)) continue;

                activeModelSet = modelSet;
                modelSet.gameObject.SetActive(true);
                ChangeModel(activeBeadLevel);
            }
        }

        public void ChangeModel(BeadType beadLevel)
        {
            if (beadLevel.Equals(BeadType.OutOfRange)) return;

            foreach (var model in activeModelSet.CollectableModels)
            {
                model.gameObject.SetActive(false);
                if (!model.BeadLevel.Equals(beadLevel)) continue;

                model.gameObject.SetActive(true);
                activeBeadLevel = model.BeadLevel;
            }
        }
    }
}