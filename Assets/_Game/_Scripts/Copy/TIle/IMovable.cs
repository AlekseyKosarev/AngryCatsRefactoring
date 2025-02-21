using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game._Scripts.Copy.TIle
{
    public interface IMovable: IPointerClickHandler, IPointerUpHandler, IDragHandler
    {
        public void Move(Vector2 posDrag);
    }
}