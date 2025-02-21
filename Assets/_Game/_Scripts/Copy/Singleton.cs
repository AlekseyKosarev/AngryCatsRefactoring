using UnityEngine;

namespace _Game._Scripts.Copy
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance;
    
        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("DESTROY SINGLETON - " + Singleton<T>.Instance.gameObject);
                Destroy(Singleton<T>.Instance.gameObject);
            }
            Instance = (T)this;
        }
    }
}