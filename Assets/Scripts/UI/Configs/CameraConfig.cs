using UnityEngine;

namespace Architecture.Ui.Configs
{
    [CreateAssetMenu(menuName = "Configs/UI/CameraConfig")]
    class CameraConfig : ScriptableObject
    {
        [SerializeField]
        internal Vector3 MainMenuCameraPosition;

        [SerializeField]
        internal Vector3 GameplayCameraPostion;

        [SerializeField] 
        internal Vector3 BattleCameraPosition;

        [SerializeField]
        internal float ScrollSensitivity = 0.2f;

        [SerializeField]
        internal Quaternion Rotation;
    }
}