using Architecture.Ui.Configs;
using UnityEngine;

namespace Architecture.UI.Views
{
    class CameraView : MonoBehaviour
    {
        [SerializeField]
        Camera Camera;

        readonly CameraConfig _cameraConfig;

        internal void Initialize()
        {
            transform.rotation = _cameraConfig.Rotation;
        }
    }
}