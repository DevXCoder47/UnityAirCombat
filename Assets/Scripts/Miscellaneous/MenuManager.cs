using UnityEngine;
using UnityEngine.SceneManagement;

namespace Miscellaneous
{
    public class MenuManager : MonoBehaviour
    {
        public void OnPlaneButtonClick()
        {
            GameSettings.SelectedVehicle = VehicleType.Plane;
            SceneManager.LoadScene("Main");
        }

        public void OnHeliButtonClick()
        {
            GameSettings.SelectedVehicle = VehicleType.Helicopter;
            SceneManager.LoadScene("Main");
        }

        public void OnExitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
