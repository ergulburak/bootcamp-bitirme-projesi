using System;
using UnityEngine;

public class ModelManager : Singleton<ModelManager>
{
    public event EventHandler<ModelType> OnGateEnterEvent;

    public void OnOnGateEnterEvent(ModelType e)
    {
        OnGateEnterEvent?.Invoke(this, e);
    }
}