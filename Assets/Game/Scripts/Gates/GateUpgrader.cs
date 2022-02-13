using Game.Scripts.Collectables;
using UnityEngine;

namespace Game.Scripts.Gates
{
    public class GateUpgrader : GateBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CollectableBase collectable))
            {
                collectable.ChangeModel((BeadType) ((int) collectable.GetBeadLevel() + 1));
            }
        }
    }
}