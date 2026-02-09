using Miscellaneous;
using UnityEngine;

namespace Armament
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private float fireRate;

        private ObjectPool _projectilePool;
        private float _nextFireTime;

        public void Init(ObjectPool poolRef)
        {
            _projectilePool = poolRef;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift) && Time.time >= _nextFireTime)
            {
                Fire();
                _nextFireTime = Time.time + fireRate;
            }
        }

        private void Fire()
        {
            var projectile = _projectilePool.Get();
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.GetComponent<Projectile>().Init(_projectilePool);
        }
    }
}
