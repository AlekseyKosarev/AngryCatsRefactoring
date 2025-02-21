using UnityEngine;

namespace _Game._Scripts.Copy.TIle
{
    public class AreasChecker: Singleton<AreasChecker>
    {
        private RectTransform _transformRECT;

        private void Start()
        {
            _transformRECT = GetComponent<RectTransform>();
            // _transform.rect.position = transform.position;
        }

        public bool CheckContains(Vector2 posObj)
        {
            var screenPos = Camera.main.WorldToScreenPoint(posObj);
            var contains = RectTransformUtility.RectangleContainsScreenPoint(_transformRECT, screenPos, Camera.main);

            return contains;
        }
    }
}