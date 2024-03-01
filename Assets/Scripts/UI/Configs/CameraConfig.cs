using UnityEngine;
namespace Architecture.Ui.Configs
{
    [CreateAssetMenu(menuName = "Configs/UI/CameraConfig")]
    class CameraConfig : ScriptableObject
    {
        [SerializeField]
        internal Vector3 PositionRelativeToGameObject;

        [SerializeField]
        internal Quaternion Rotation;
    }
}