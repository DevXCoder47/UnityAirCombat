using System.Collections.Generic;
using UnityEngine;

namespace Miscellaneous
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _initialSize;

        private readonly Queue<GameObject> _pool = new();

        void Start()
        {
            for (int i = 0; i < _initialSize; i++)
            {
                CreateObject();
            }
        }

        private GameObject CreateObject()
        {
            var obj = Instantiate(_prefab, transform);
            obj.SetActive(false);
            _pool.Enqueue(obj);
            return obj;
        }

        public GameObject Get()
        {
            if (_pool.Count == 0)
                CreateObject();

            var obj = _pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        public void Return(GameObject obj)
        {
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}
