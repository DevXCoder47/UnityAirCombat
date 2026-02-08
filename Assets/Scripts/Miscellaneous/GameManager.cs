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

        void Start()
        {
            SpawnSelectedVehicle();
        }

        private void SpawnSelectedVehicle()
        {
            switch (GameSettings.SelectedVehicle)
            {
                case VehicleType.Plane:
                    Instantiate(planePrefab, planeZone.position, planeZone.rotation);
                    break;

                case VehicleType.Helicopter:
                    Instantiate(helicopterPrefab, helicopterZone.position, helicopterZone.rotation);
                    break;
            }
        }
    }
}
