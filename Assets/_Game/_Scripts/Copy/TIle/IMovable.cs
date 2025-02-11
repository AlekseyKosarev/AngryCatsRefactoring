using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildSystem
{
    public interface IMovable: IPointerClickHandler, IPointerUpHandler, IDragHandler
    {
        public void Move(Vector2 posDrag);
    }
}