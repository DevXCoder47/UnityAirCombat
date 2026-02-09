using Miscellaneous;
using UnityEngine;

namespace Armament
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;

        private float _timer;
        private ObjectPool _pool;

        public void Init(ObjectPool poolRef)
        {
            _timer = _lifeTime;
            _pool = poolRef;
        }

        void Update()
        {
            transform.Translate(Vector3.forward * _speed *  Time.deltaTime);

            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                _pool.Return(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null) health.TakeDamage(_damage);
            Debug.Log("Hit");

            _pool.Return(gameObject);
        }
    }
}
