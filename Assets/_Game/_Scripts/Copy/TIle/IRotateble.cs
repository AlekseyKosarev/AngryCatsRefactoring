using UnityEngine.EventSystems;

namespace _Game._Scripts.Copy.TIle
{
    public interface IRotateble: IPointerUpHandler
    {
        public void Rotate();
    }
}