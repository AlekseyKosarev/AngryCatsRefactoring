using UnityEngine.EventSystems;

namespace BuildSystem
{
    public interface IRotateble: IPointerUpHandler
    {
        public void Rotate();
    }
}