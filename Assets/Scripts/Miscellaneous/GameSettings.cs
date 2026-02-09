using UnityEngine;

namespace Miscellaneous
{
    public enum VehicleType
    {
        Plane,
        Helicopter
    }

    public static class GameSettings
    {
        public static VehicleType SelectedVehicle;
    }
}
