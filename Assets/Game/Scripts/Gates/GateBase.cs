using System;
using UnityEngine;

public class GateBase : MonoBehaviour
{
    [SerializeField] private ModelType modelType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            ModelManager.Instance.OnOnGateEnterEvent(modelType);
        }
    }
}