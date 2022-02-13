using System;

namespace Game.Scripts.MeshChangerSystem
{
    public class ModelManager : Singleton<ModelManager>
    {
        public event EventHandler<ModelType> OnGateEnterEvent;

        public void FireGateEnterEvent(ModelType e)
        {
            OnGateEnterEvent?.Invoke(this, e);
        }
    }
}