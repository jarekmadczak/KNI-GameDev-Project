using UnityEngine;
using UnityEngine.InputSystem;

namespace Architecture.Ui.Configs
{
    [CreateAssetMenu(menuName = "Configs/UI/UIConfig")]
    class UIConfig : ScriptableObject
    {
        [SerializeField]
        internal InputActionAsset InputActionAsset;
    }
}
