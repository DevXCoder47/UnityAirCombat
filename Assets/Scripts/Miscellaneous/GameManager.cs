using Armament;
using Unity.VisualScripting;
using UnityEngine;

namespace Miscellaneous
{
    public class GameManager : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject planePrefab;
        [SerializeField] private GameObject helicopterPrefab;

        [Header("Spawn Zones")]
        [SerializeField] private Transform planeZone;
        [SerializeField] private Transform helicopterZone;

        [Header("Pool")]
        [SerializeField] private ObjectPool pool;

        void Start()
        {
            SpawnSelectedVehicle();
        }

        private void SpawnSelectedVehicle()
        {
            switch (GameSettings.SelectedVehicle)
            {
                case VehicleType.Plane: SpawnPlane(); break;
                case VehicleType.Helicopter: SpawnHelicopter(); break;
            }
        }

        private void SpawnPlane()
        {
            var planeGO = Instantiate(planePrefab, planeZone.position, planeZone.rotation);

            var gun = planeGO.GetComponentInChildren<Gun>();

            gun.Init(pool);
        }

        private void SpawnHelicopter()
        {
            Instantiate(helicopterPrefab, helicopterZone.position, helicopterZone.rotation);
        }
    }
}
