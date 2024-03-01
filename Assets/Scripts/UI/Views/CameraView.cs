using Architecture.Ui.Configs;
using UnityEngine;

namespace Architecture.UI.Views
{
    class CameraView : MonoBehaviour
    {
        [SerializeField]
        Camera Camera;

        [SerializeField]
        CameraConfig _cameraConfig;


        GameObject _currentFocus;
        internal void Initialize()
        {
            transform.rotation = _cameraConfig.Rotation;
        }
        internal void FocusOnGameObject(GameObject go) => _currentFocus = go;

        internal void UpdateCameraPosition()
        {
            if (_currentFocus == null)
                return;
            transform.position = _currentFocus.transform.position + _cameraConfig.PositionRelativeToGameObject;
        }
    }
}